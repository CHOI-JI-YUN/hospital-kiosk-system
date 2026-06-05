using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Kiosk
{
    public partial class FormReceipt : Form
    {
        private string patientName;
        private string dept;
        private int fee;
        private string payMethod;
        private DateTime payTime;

        public FormReceipt(string patientName, string dept, int fee, string payMethod)
        {
            InitializeComponent();
            this.patientName = patientName;
            this.dept = dept;
            this.fee = fee;
            this.payMethod = payMethod;
            this.payTime = DateTime.Now;
        }

        private void panelReceipt_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.Clear(Color.White);

            int w = panelReceipt.Width;
            int y = 15;

            // ── 상단 병원명 ──
            using (var f = new Font("맑은 고딕", 16, FontStyle.Bold))
            {
                var sz = g.MeasureString("우리들병원", f);
                g.DrawString("우리들병원", f, Brushes.Black, (w - sz.Width) / 2, y);
                y += (int)sz.Height + 2;
            }

            using (var f = new Font("맑은 고딕", 8))
            {
                string addr = "서울특별시 강남구 테헤란로 123";
                var sz = g.MeasureString(addr, f);
                g.DrawString(addr, f, Brushes.Gray, (w - sz.Width) / 2, y);
                y += (int)sz.Height;

                string tel = "TEL: 02-1234-5678";
                sz = g.MeasureString(tel, f);
                g.DrawString(tel, f, Brushes.Gray, (w - sz.Width) / 2, y);
                y += (int)sz.Height + 8;
            }

            // ── 구분선 (점선) ──
            DrawDashedLine(g, y, w);
            y += 12;

            // ── 영수증 제목 ──
            using (var f = new Font("맑은 고딕", 13, FontStyle.Bold))
            {
                string title = "진 료 비 영 수 증";
                var sz = g.MeasureString(title, f);
                g.DrawString(title, f, Brushes.Black, (w - sz.Width) / 2, y);
                y += (int)sz.Height + 10;
            }

            // ── 구분선 ──
            DrawDashedLine(g, y, w);
            y += 12;

            // ── 상세 항목 ──
            var fontLabel = new Font("맑은 고딕", 10, FontStyle.Regular);
            var fontValue = new Font("맑은 고딕", 10, FontStyle.Bold);
            int labelX = 20;
            int valueX = 170;

            y = DrawRow(g, y, "환자명", patientName, fontLabel, fontValue, labelX, valueX);
            y = DrawRow(g, y, "진료과", dept, fontLabel, fontValue, labelX, valueX);
            y = DrawRow(g, y, "발행일시", payTime.ToString("yyyy-MM-dd HH:mm"), fontLabel, fontValue, labelX, valueX);
            y = DrawRow(g, y, "결제수단", payMethod, fontLabel, fontValue, labelX, valueX);

            y += 5;
            DrawDashedLine(g, y, w);
            y += 12;

            // ── 금액 상세 ──
            y = DrawRow(g, y, "진찰료", $"{fee:N0}원", fontLabel, fontValue, labelX, valueX);

            int vat = (int)(fee * 0.1);
            y = DrawRow(g, y, "부가세 (10%)", $"{vat:N0}원", fontLabel, fontValue, labelX, valueX);

            y += 5;
            DrawDashedLine(g, y, w);
            y += 10;

            // ── 합계 ──
            int total = fee + vat;
            using (var fBig = new Font("맑은 고딕", 14, FontStyle.Bold))
            {
                g.DrawString("합  계", fBig, Brushes.Black, labelX, y);
                string totalStr = $"{total:N0}원";
                var sz = g.MeasureString(totalStr, fBig);
                g.DrawString(totalStr, fBig, new SolidBrush(Color.FromArgb(30, 60, 114)),
                    w - 20 - sz.Width, y);
                y += (int)sz.Height + 8;
            }

            DrawDashedLine(g, y, w);
            y += 15;

            // ── 바코드 시뮬레이션 ──
            DrawBarcode(g, (w - 200) / 2, y, 200, 40);
            y += 50;

            // ── 영수증 번호 ──
            using (var f = new Font("맑은 고딕", 8))
            {
                string num = $"No. {payTime:yyyyMMddHHmmss}-{new Random().Next(1000, 9999)}";
                var sz = g.MeasureString(num, f);
                g.DrawString(num, f, Brushes.Gray, (w - sz.Width) / 2, y);
                y += (int)sz.Height + 10;
            }

            // ── 하단 안내 ──
            using (var f = new Font("맑은 고딕", 8))
            {
                string msg = "이용해 주셔서 감사합니다.";
                var sz = g.MeasureString(msg, f);
                g.DrawString(msg, f, Brushes.Gray, (w - sz.Width) / 2, y);
            }

            fontLabel.Dispose();
            fontValue.Dispose();
        }

        private int DrawRow(Graphics g, int y, string label, string value,
            Font fLabel, Font fValue, int labelX, int valueX)
        {
            g.DrawString(label, fLabel, Brushes.DimGray, labelX, y);
            g.DrawString(value, fValue, Brushes.Black, valueX, y);
            return y + 26;
        }

        private void DrawDashedLine(Graphics g, int y, int width)
        {
            using (var pen = new Pen(Color.FromArgb(180, 180, 180), 1))
            {
                pen.DashStyle = DashStyle.Dash;
                g.DrawLine(pen, 15, y, width - 15, y);
            }
        }

        private void DrawBarcode(Graphics g, int x, int y, int width, int height)
        {
            var rnd = new Random(123);
            int posX = x;
            while (posX < x + width)
            {
                int barW = rnd.Next(1, 4);
                bool black = rnd.Next(2) == 0;
                if (black)
                    g.FillRectangle(Brushes.Black, posX, y, barW, height);
                posX += barW + 1;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
