namespace Kiosk
{
    partial class FormPayment
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPatientInfo = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblAmountValue = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnCreditCard = new System.Windows.Forms.Button();
            this.btnKakaoPay = new System.Windows.Forms.Button();
            this.btnNaverPay = new System.Windows.Forms.Button();
            this.btnCash = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblLine = new System.Windows.Forms.Label();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 60, 114);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(420, 55);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "결제 방법 선택";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPatientInfo
            // 
            this.lblPatientInfo.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular);
            this.lblPatientInfo.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblPatientInfo.Location = new System.Drawing.Point(20, 55);
            this.lblPatientInfo.Name = "lblPatientInfo";
            this.lblPatientInfo.Size = new System.Drawing.Size(380, 25);
            this.lblPatientInfo.TabIndex = 1;
            this.lblPatientInfo.Text = "환자: -";
            this.lblPatientInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLine
            // 
            this.lblLine.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.lblLine.Location = new System.Drawing.Point(30, 88);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(360, 1);
            this.lblLine.TabIndex = 10;
            // 
            // lblAmount
            // 
            this.lblAmount.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblAmount.Location = new System.Drawing.Point(20, 98);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(120, 30);
            this.lblAmount.TabIndex = 2;
            this.lblAmount.Text = "결제 금액";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAmountValue
            // 
            this.lblAmountValue.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.lblAmountValue.ForeColor = System.Drawing.Color.FromArgb(30, 60, 114);
            this.lblAmountValue.Location = new System.Drawing.Point(140, 92);
            this.lblAmountValue.Name = "lblAmountValue";
            this.lblAmountValue.Size = new System.Drawing.Size(260, 40);
            this.lblAmountValue.TabIndex = 3;
            this.lblAmountValue.Text = "0 원";
            this.lblAmountValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnCreditCard);
            this.panelButtons.Controls.Add(this.btnKakaoPay);
            this.panelButtons.Controls.Add(this.btnNaverPay);
            this.panelButtons.Controls.Add(this.btnCash);
            this.panelButtons.Location = new System.Drawing.Point(20, 145);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(380, 260);
            this.panelButtons.TabIndex = 4;
            // 
            // btnCreditCard
            // 
            this.btnCreditCard.BackColor = System.Drawing.Color.FromArgb(30, 60, 114);
            this.btnCreditCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreditCard.FlatAppearance.BorderSize = 0;
            this.btnCreditCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreditCard.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.btnCreditCard.ForeColor = System.Drawing.Color.White;
            this.btnCreditCard.Location = new System.Drawing.Point(0, 0);
            this.btnCreditCard.Name = "btnCreditCard";
            this.btnCreditCard.Size = new System.Drawing.Size(380, 55);
            this.btnCreditCard.TabIndex = 0;
            this.btnCreditCard.Text = "💳  신용카드";
            this.btnCreditCard.UseVisualStyleBackColor = false;
            this.btnCreditCard.Click += new System.EventHandler(this.btnCreditCard_Click);
            // 
            // btnKakaoPay
            // 
            this.btnKakaoPay.BackColor = System.Drawing.Color.FromArgb(254, 229, 0);
            this.btnKakaoPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKakaoPay.FlatAppearance.BorderSize = 0;
            this.btnKakaoPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKakaoPay.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.btnKakaoPay.ForeColor = System.Drawing.Color.FromArgb(60, 30, 0);
            this.btnKakaoPay.Location = new System.Drawing.Point(0, 65);
            this.btnKakaoPay.Name = "btnKakaoPay";
            this.btnKakaoPay.Size = new System.Drawing.Size(380, 55);
            this.btnKakaoPay.TabIndex = 1;
            this.btnKakaoPay.Text = "카카오페이";
            this.btnKakaoPay.UseVisualStyleBackColor = false;
            this.btnKakaoPay.Click += new System.EventHandler(this.btnKakaoPay_Click);
            // 
            // btnNaverPay
            // 
            this.btnNaverPay.BackColor = System.Drawing.Color.FromArgb(3, 199, 90);
            this.btnNaverPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNaverPay.FlatAppearance.BorderSize = 0;
            this.btnNaverPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNaverPay.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.btnNaverPay.ForeColor = System.Drawing.Color.White;
            this.btnNaverPay.Location = new System.Drawing.Point(0, 130);
            this.btnNaverPay.Name = "btnNaverPay";
            this.btnNaverPay.Size = new System.Drawing.Size(380, 55);
            this.btnNaverPay.TabIndex = 2;
            this.btnNaverPay.Text = "네이버페이";
            this.btnNaverPay.UseVisualStyleBackColor = false;
            this.btnNaverPay.Click += new System.EventHandler(this.btnNaverPay_Click);
            // 
            // btnCash
            // 
            this.btnCash.BackColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.btnCash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCash.FlatAppearance.BorderSize = 0;
            this.btnCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCash.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.btnCash.ForeColor = System.Drawing.Color.White;
            this.btnCash.Location = new System.Drawing.Point(0, 195);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(380, 55);
            this.btnCash.TabIndex = 3;
            this.btnCash.Text = "💵  현금";
            this.btnCash.UseVisualStyleBackColor = false;
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.btnCancel.FlatAppearance.BorderSize = 1;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.btnCancel.Location = new System.Drawing.Point(150, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 35);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(420, 470);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.lblAmountValue);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.lblPatientInfo);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "결제";
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPatientInfo;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblAmountValue;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnCreditCard;
        private System.Windows.Forms.Button btnKakaoPay;
        private System.Windows.Forms.Button btnNaverPay;
        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblLine;
    }
}
