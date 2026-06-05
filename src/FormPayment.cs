using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Kiosk
{
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }
    }

    public partial class FormPayment : Form
    {
        public bool PaymentCompleted { get; private set; } = false;
        public string SelectedMethod { get; private set; } = "";

        private string patientName;
        private string dept;
        private int fee;
        private int totalFee;

        private DoubleBufferedPanel panelAnim;
        private Image payImage;
        private Label lblAnimStatus;
        private ProgressBar progBar;
        private System.Windows.Forms.Timer animTimer;
        private System.Windows.Forms.Timer drawTimer;
        private int animStep = 0;
        private string animMethod = "";

        // QR 스캔라인
        private int scanLineY = 40;
        private bool scanDown = true;

        // 신용카드 삽입 (아래→위)
        private int cardY;
        private int cardTargetY = 70;

        public FormPayment(string patientName, string dept, int fee)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.patientName = patientName;
            this.dept = dept;
            this.fee = fee;
            this.totalFee = fee + (int)(fee * 0.1);

            lblPatientInfo.Text = $"{patientName}  |  {dept}";
            lblAmountValue.Text = $"{totalFee:N0} 원";

            this.Load += (s, e) =>
            {
                ApplyRound(btnCreditCard, 12);
                ApplyRound(btnKakaoPay, 12);
                ApplyRound(btnNaverPay, 12);
                ApplyRound(btnCash, 12);
                ApplyRound(btnCancel, 8);
            };
        }

        private void btnCreditCard_Click(object sender, EventArgs e) => StartPayment("신용카드");
        private void btnKakaoPay_Click(object sender, EventArgs e) => StartPayment("카카오페이");
        private void btnNaverPay_Click(object sender, EventArgs e) => StartPayment("네이버페이");

        private void btnCash_Click(object sender, EventArgs e)
        {
            KioskMessageBox.Show(
                this,
                $"{patientName}님, 현금 결제는 창구에서 진행됩니다.\n\n" +
                $"결제 금액: {totalFee:N0}원 (부가세 포함)\n" +
                "1번 창구로 이동해 주세요.",
                "현금 결제 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SelectedMethod = "현금";
            PaymentCompleted = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void StartPayment(string method)
        {
            animMethod = method;
            animStep = 0;
            scanLineY = 40;
            scanDown = true;

            panelButtons.Visible = false;
            btnCancel.Visible = false;

            // PayImages.cs에서 Base64 이미지 로드 (100% 확실)
            payImage = PayImages.GetImage(method);

            // 더블버퍼링 패널
            panelAnim = new DoubleBufferedPanel
            {
                Location = new Point(50, 132),
                Size = new Size(320, 260),
                BackColor = Color.White
            };
            panelAnim.Paint += PanelAnim_Paint;
            this.Controls.Add(panelAnim);
            panelAnim.BringToFront();

            // 카드 시작 위치: 패널 아래 바깥
            cardY = panelAnim.Height + 20;

            lblAnimStatus = new Label
            {
                Location = new Point(20, 400),
                Size = new Size(380, 25),
                Font = new Font("맑은 고딕", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 60, 114),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = GetStatusText(0)
            };
            this.Controls.Add(lblAnimStatus);
            lblAnimStatus.BringToFront();

            progBar = new ProgressBar
            {
                Location = new Point(60, 430),
                Size = new Size(300, 16),
                Minimum = 0,
                Maximum = 100,
                Value = 0,
                Style = ProgressBarStyle.Continuous
            };
            this.Controls.Add(progBar);
            progBar.BringToFront();

            drawTimer = new System.Windows.Forms.Timer { Interval = 30 };
            drawTimer.Tick += DrawTimer_Tick;
            drawTimer.Start();

            animTimer = new System.Windows.Forms.Timer { Interval = 900 };
            animTimer.Tick += AnimTimer_Tick;
            animTimer.Start();
        }

        // ══════════════════════════════════════
        //  Paint
        // ══════════════════════════════════════
        private void PanelAnim_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.Clear(Color.White);

            int w = panelAnim.Width;
            int h = panelAnim.Height;

            // 1) 배경 이미지
            if (payImage != null)
            {
                float ratioW = (float)w / payImage.Width;
                float ratioH = (float)h / payImage.Height;
                float ratio = Math.Min(ratioW, ratioH);
                int imgW = (int)(payImage.Width * ratio);
                int imgH = (int)(payImage.Height * ratio);
                int imgX = (w - imgW) / 2;
                int imgY = (h - imgH) / 2;
                g.DrawImage(payImage, imgX, imgY, imgW, imgH);
            }

            // 2) 오버레이
            if (animStep < 4)
            {
                if (animMethod == "신용카드")
                    DrawCardOverlay(g, w, h);
                else
                    DrawScanOverlay(g, w, h);
            }

            // 3) 완료
            if (animStep >= 4)
                DrawCheckMark(g, w / 2, h / 2);
        }

        // ── 신용카드: 세로 카드가 아래→위로 올라감 ──
        private void DrawCardOverlay(Graphics g, int w, int h)
        {
            int cW = 80, cH = 130;
            int cx = w / 2 - cW / 2;
            var cRect = new Rectangle(cx, cardY, cW, cH);

            // 그림자
            FillRR(g, new SolidBrush(Color.FromArgb(40, 0, 0, 0)),
                new Rectangle(cx + 3, cardY + 3, cW, cH), 10);

            // 카드 본체
            using (var br = new LinearGradientBrush(cRect,
                Color.FromArgb(25, 55, 115), Color.FromArgb(60, 120, 180), 90f))
                FillRR(g, br, cRect, 10);

            // IC칩
            int chipX = cRect.X + cW / 2 - 14;
            int chipY = cRect.Y + 20;
            g.FillRectangle(new SolidBrush(Color.FromArgb(218, 175, 50)),
                chipX, chipY, 28, 20);
            using (var cp = new Pen(Color.FromArgb(180, 145, 30), 1))
            {
                g.DrawLine(cp, chipX + 2, chipY + 10, chipX + 26, chipY + 10);
                g.DrawLine(cp, chipX + 14, chipY + 2, chipX + 14, chipY + 18);
            }

            // 카드 번호
            using (var f = new Font("Consolas", 7f, FontStyle.Bold))
            {
                var c = new SolidBrush(Color.FromArgb(190, 220, 255));
                g.DrawString("1234", f, c, cRect.X + 15, cRect.Y + 50);
                g.DrawString("5678", f, c, cRect.X + 15, cRect.Y + 64);
                g.DrawString("9012", f, c, cRect.X + 15, cRect.Y + 78);
                g.DrawString("3456", f, c, cRect.X + 15, cRect.Y + 92);
            }

            // NFC
            using (var np = new Pen(Color.FromArgb(160, 210, 255), 1.5f))
            {
                int nfcX = cRect.Right - 25, nfcY = cRect.Y + 50;
                g.DrawArc(np, nfcX, nfcY, 10, 10, -45, 90);
                g.DrawArc(np, nfcX - 3, nfcY - 3, 16, 16, -45, 90);
                g.DrawArc(np, nfcX - 6, nfcY - 6, 22, 22, -45, 90);
            }

            using (var f = new Font("맑은 고딕", 6f))
                g.DrawString("12/25", f, new SolidBrush(Color.FromArgb(160, 200, 240)),
                    cRect.X + 15, cRect.Y + 112);
        }

        // ── 카카오/네이버: 스캔 라인 ──
        private void DrawScanOverlay(Graphics g, int w, int h)
        {
            Color lc = animMethod == "카카오페이"
                ? Color.FromArgb(254, 229, 0) : Color.FromArgb(3, 199, 90);

            using (var pen = new Pen(Color.FromArgb(230, lc.R, lc.G, lc.B), 3))
                g.DrawLine(pen, 20, scanLineY, w - 20, scanLineY);

            int gH = 12;
            var gRect = new Rectangle(20, Math.Max(scanLineY - gH, 0), w - 40, gH * 2);
            if (gRect.Height > 0 && gRect.Width > 0)
            {
                try
                {
                    using (var br = new LinearGradientBrush(gRect,
                        Color.FromArgb(60, lc.R, lc.G, lc.B),
                        Color.Transparent, LinearGradientMode.Vertical))
                        g.FillRectangle(br, gRect);
                }
                catch { }
            }

            Color fc = animMethod == "카카오페이"
                ? Color.FromArgb(200, 180, 0) : Color.FromArgb(3, 180, 80);
            int cl = 28, m = 30;
            int top = 30, bot = h - 20, left = m, right = w - m;
            using (var pen = new Pen(fc, 3))
            {
                g.DrawLine(pen, left, top, left + cl, top);
                g.DrawLine(pen, left, top, left, top + cl);
                g.DrawLine(pen, right, top, right - cl, top);
                g.DrawLine(pen, right, top, right, top + cl);
                g.DrawLine(pen, left, bot, left + cl, bot);
                g.DrawLine(pen, left, bot, left, bot - cl);
                g.DrawLine(pen, right, bot, right - cl, bot);
                g.DrawLine(pen, right, bot, right, bot - cl);
            }
        }

        private void DrawCheckMark(Graphics g, int cx, int cy)
        {
            g.FillEllipse(new SolidBrush(Color.FromArgb(200, 255, 255, 255)),
                cx - 38, cy - 38, 76, 76);
            g.FillEllipse(new SolidBrush(Color.FromArgb(230, 40, 200, 80)),
                cx - 30, cy - 30, 60, 60);
            using (var cp = new Pen(Color.White, 5) { LineJoin = LineJoin.Round })
            {
                g.DrawLine(cp, cx - 15, cy, cx - 4, cy + 13);
                g.DrawLine(cp, cx - 4, cy + 13, cx + 18, cy - 12);
            }
        }

        // ══════════════════════════════════════
        //  타이머
        // ══════════════════════════════════════
        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            if (animMethod == "신용카드")
            {
                // 아래→위로 올라감
                if (cardY > cardTargetY)
                    cardY -= 4;
            }
            else
            {
                int speed = 3;
                if (scanDown)
                {
                    scanLineY += speed;
                    if (scanLineY >= panelAnim.Height - 25) scanDown = false;
                }
                else
                {
                    scanLineY -= speed;
                    if (scanLineY <= 35) scanDown = true;
                }
            }
            panelAnim?.Invalidate();
        }

        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            animStep++;
            if (animStep <= 4)
            {
                lblAnimStatus.Text = GetStatusText(animStep);
                progBar.Value = Math.Min(animStep * 25, 100);
                if (animStep == 4)
                {
                    lblAnimStatus.ForeColor = Color.Green;
                    progBar.Value = 100;
                    if (drawTimer != null) { drawTimer.Stop(); drawTimer.Dispose(); drawTimer = null; }
                    panelAnim?.Invalidate();
                }
            }
            else
            {
                animTimer.Stop(); animTimer.Dispose();
                FinishPayment();
            }
        }

        private string GetStatusText(int step)
        {
            if (animMethod == "신용카드")
            {
                switch (step)
                {
                    case 0: return "카드를 넣거나 긁어주세요...";
                    case 1: return "카드 읽는 중...";
                    case 2: return "카드 정보 확인 중...";
                    case 3: return "승인 요청 중...";
                    case 4: return "✔ 승인 완료!";
                    default: return "";
                }
            }
            else if (animMethod == "카카오페이")
            {
                switch (step)
                {
                    case 0: return "바코드 또는 QR코드를 스캔해주세요";
                    case 1: return "QR코드 인식 중...";
                    case 2: return "카카오페이 결제 승인 중...";
                    case 3: return "결제 처리 중...";
                    case 4: return "✔ 카카오페이 결제 완료!";
                    default: return "";
                }
            }
            else
            {
                switch (step)
                {
                    case 0: return "QR코드를 스캔해주세요";
                    case 1: return "QR코드 인식 중...";
                    case 2: return "네이버페이 결제 승인 중...";
                    case 3: return "결제 처리 중...";
                    case 4: return "✔ 네이버페이 결제 완료!";
                    default: return "";
                }
            }
        }

        private void FinishPayment()
        {
            SelectedMethod = animMethod;
            PaymentCompleted = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ApplyRound(Button btn, int radius)
        {
            var path = new GraphicsPath();
            var rect = new Rectangle(0, 0, btn.Width, btn.Height);
            int r = radius * 2;
            path.AddArc(rect.X, rect.Y, r, r, 180, 90);
            path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
            path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
            path.CloseFigure();
            btn.Region = new Region(path);
        }

        private static void FillRR(Graphics g, Brush brush, Rectangle rect, int radius)
        {
            using (var path = new GraphicsPath())
            {
                int r = radius * 2;
                path.AddArc(rect.X, rect.Y, r, r, 180, 90);
                path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
                path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
                path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
                path.CloseFigure();
                g.FillPath(brush, path);
            }
        }
    }
}