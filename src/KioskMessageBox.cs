using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Kiosk
{
    public static class KioskMessageBox
    {
        public static DialogResult Show(Form owner, string message,
            string title = "알림",
            MessageBoxButtons buttons = MessageBoxButtons.OK,
            MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            using (var dlg = new Form())
            {
                dlg.FormBorderStyle = FormBorderStyle.None;
                dlg.BackColor = Color.White;
                dlg.ShowInTaskbar = false;
                dlg.TopMost = true;

                int dlgWidth = 300;
                int pad = 18;
                int iconAreaW = 24;
                int gap = 8;
                int textLeft = pad + iconAreaW + gap;
                int textWidth = dlgWidth - textLeft - pad - 10;

                // 아이콘 설정
                string iconText = "ℹ";
                Color iconColor = Color.FromArgb(70, 130, 180);
                if (icon == MessageBoxIcon.Warning || icon == MessageBoxIcon.Exclamation)
                { iconText = "⚠"; iconColor = Color.FromArgb(230, 160, 0); }
                else if (icon == MessageBoxIcon.Error)
                { iconText = "✖"; iconColor = Color.FromArgb(200, 50, 50); }
                else if (icon == MessageBoxIcon.Question)
                { iconText = "?"; iconColor = Color.FromArgb(70, 130, 180); }

                // 텍스트 높이 계산
                Font msgFont = new Font("맑은 고딕", 9.5f);
                Size textSize;
                using (var g = Graphics.FromHwnd(IntPtr.Zero))
                {
                    textSize = TextRenderer.MeasureText(g, message, msgFont, new Size(textWidth, 0),
                        TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);
                }

                int topY = 22;
                int contentH = Math.Max(textSize.Height, 22);
                int dlgHeight = topY + contentH + 20 + 42;
                if (dlgHeight < 120) dlgHeight = 120;

                dlg.Size = new Size(dlgWidth, dlgHeight);

                // 아이콘
                var lblIcon = new Label
                {
                    Text = iconText,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    ForeColor = iconColor,
                    AutoSize = true,
                    Location = new Point(pad, topY - 1)
                };
                dlg.Controls.Add(lblIcon);

                // 메시지
                var lblMsg = new Label
                {
                    Text = message,
                    Font = msgFont,
                    ForeColor = Color.FromArgb(50, 50, 50),
                    Size = textSize,
                    Location = new Point(textLeft, topY)
                };
                dlg.Controls.Add(lblMsg);

                // 닫기 X
                var btnClose = new Label
                {
                    Text = "✕",
                    Font = new Font("맑은 고딕", 9),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Cursor = Cursors.Hand,
                    Location = new Point(dlgWidth - 22, 6)
                };
                btnClose.Click += (s, e) => { dlg.DialogResult = DialogResult.Cancel; dlg.Close(); };
                dlg.Controls.Add(btnClose);

                // owner 폼 정중앙 배치
                dlg.StartPosition = FormStartPosition.Manual;
                if (owner != null)
                {
                    Rectangle ob = owner.Bounds;
                    int x = ob.Left + (ob.Width - dlgWidth) / 2;
                    int y = ob.Top + (ob.Height - dlgHeight) / 2;

                    Rectangle screen = Screen.FromControl(owner).WorkingArea;
                    if (x < screen.Left) x = screen.Left;
                    if (y < screen.Top) y = screen.Top;
                    if (x + dlgWidth > screen.Right) x = screen.Right - dlgWidth;
                    if (y + dlgHeight > screen.Bottom) y = screen.Bottom - dlgHeight;

                    dlg.Location = new Point(x, y);
                }
                else
                {
                    dlg.StartPosition = FormStartPosition.CenterScreen;
                }

                // 둥근 테두리
                int radius = 12;
                var rgPath = new GraphicsPath();
                rgPath.AddArc(0, 0, radius, radius, 180, 90);
                rgPath.AddArc(dlgWidth - radius, 0, radius, radius, 270, 90);
                rgPath.AddArc(dlgWidth - radius, dlgHeight - radius, radius, radius, 0, 90);
                rgPath.AddArc(0, dlgHeight - radius, radius, radius, 90, 90);
                rgPath.CloseFigure();
                dlg.Region = new Region(rgPath);

                dlg.Paint += (s, e) =>
                {
                    using (var pen = new Pen(Color.FromArgb(200, 200, 200), 1.5f))
                    {
                        var bp = new GraphicsPath();
                        bp.AddArc(1, 1, radius, radius, 180, 90);
                        bp.AddArc(dlgWidth - radius - 1, 1, radius, radius, 270, 90);
                        bp.AddArc(dlgWidth - radius - 1, dlgHeight - radius - 1, radius, radius, 0, 90);
                        bp.AddArc(1, dlgHeight - radius - 1, radius, radius, 90, 90);
                        bp.CloseFigure();
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.DrawPath(pen, bp);
                    }
                };

                // 버튼
                int btnY = dlgHeight - 42;

                if (buttons == MessageBoxButtons.YesNo)
                {
                    var btnYes = CreateButton("예(Y)", dlgWidth / 2 - 108, btnY, 100, 32);
                    btnYes.Click += (s, e) => { dlg.DialogResult = DialogResult.Yes; dlg.Close(); };
                    dlg.Controls.Add(btnYes);

                    var btnNo = CreateButton("아니요(N)", dlgWidth / 2 + 8, btnY, 100, 32);
                    btnNo.BackColor = Color.FromArgb(240, 240, 240);
                    btnNo.ForeColor = Color.FromArgb(80, 80, 80);
                    btnNo.Click += (s, e) => { dlg.DialogResult = DialogResult.No; dlg.Close(); };
                    dlg.Controls.Add(btnNo);
                }
                else
                {
                    var btnOk = CreateButton("확인", dlgWidth / 2 - 42, btnY, 84, 32);
                    btnOk.Click += (s, e) => { dlg.DialogResult = DialogResult.OK; dlg.Close(); };
                    dlg.Controls.Add(btnOk);
                    dlg.AcceptButton = btnOk;
                }

                dlg.ShowDialog(owner);
                return dlg.DialogResult;
            }
        }

        private static Button CreateButton(string text, int x, int y, int w, int h)
        {
            var btn = new Button
            {
                Text = text,
                Font = new Font("맑은 고딕", 9, FontStyle.Bold),
                Size = new Size(w, h),
                Location = new Point(x, y),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(70, 130, 180),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;

            var btnPath = new GraphicsPath();
            btnPath.AddArc(0, 0, 8, 8, 180, 90);
            btnPath.AddArc(w - 8, 0, 8, 8, 270, 90);
            btnPath.AddArc(w - 8, h - 8, 8, 8, 0, 90);
            btnPath.AddArc(0, h - 8, 8, 8, 90, 90);
            btnPath.CloseFigure();
            btn.Region = new Region(btnPath);

            return btn;
        }
    }
}