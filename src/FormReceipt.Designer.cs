namespace Kiosk
{
    partial class FormReceipt
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelReceipt = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelReceipt
            // 
            this.panelReceipt.BackColor = System.Drawing.Color.White;
            this.panelReceipt.Location = new System.Drawing.Point(30, 20);
            this.panelReceipt.Name = "panelReceipt";
            this.panelReceipt.Size = new System.Drawing.Size(320, 480);
            this.panelReceipt.TabIndex = 0;
            this.panelReceipt.Paint += new System.Windows.Forms.PaintEventHandler(this.panelReceipt_Paint);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(30, 60, 114);
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(120, 515);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "확인";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.ClientSize = new System.Drawing.Size(380, 570);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panelReceipt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "영수증";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelReceipt;
        private System.Windows.Forms.Button btnClose;
    }
}
