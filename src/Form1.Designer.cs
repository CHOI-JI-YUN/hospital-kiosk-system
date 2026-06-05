namespace Kiosk
{
    partial class tabMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tabMain));
            tabWaitCall = new TabPage();
            lblAdWait = new Label();
            pictureBox2 = new PictureBox();
            btnHome = new Button();
            btnPrescription = new Button();
            Waitlist = new Label();
            btnComplete = new Button();
            btnCall = new Button();
            lblWaitTotal = new Label();
            lblNowCalling = new Label();
            dgvWait = new DataGridView();
            tabRegister = new TabPage();
            lbregister = new Label();
            lblAdRegister = new Label();
            pictureBox1 = new PictureBox();
            btnHomeRegister = new Button();
            panelNew = new Panel();
            grpAgree = new GroupBox();
            rdoAgreeNo = new RadioButton();
            rdoAgreeYes = new RadioButton();
            txtAddr = new TextBox();
            btnSearchExisting = new Button();
            lblAddr = new Label();
            btnRegisterNew = new Button();
            label5 = new Label();
            txtName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            label3 = new Label();
            txtBirth = new TextBox();
            panelMedical = new Panel();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            cmbDept = new ComboBox();
            label2 = new Label();
            clbSymptoms = new CheckedListBox();
            btnSubmit = new Button();
            groupBox1 = new GroupBox();
            rdoExisting = new RadioButton();
            rdoNew = new RadioButton();
            panelExisting = new Panel();
            txtExName = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            txtExBirth = new Label();
            TabPage = new TabControl();
            tabHome = new TabPage();
            pictureBox9 = new PictureBox();
            pictureBox8 = new PictureBox();
            label6 = new Label();
            label4 = new Label();
            lblWaitRegister = new Label();
            btnGoRegister = new Button();
            pictureBox6 = new PictureBox();
            lblWaitPay = new Label();
            btnGoPay = new Button();
            lbHomeSmall = new Label();
            lbHomeBig = new Label();
            tabPay = new TabPage();
            lblAdPay = new Label();
            label7 = new Label();
            pictureBox7 = new PictureBox();
            btnReset = new Button();
            pictureBox5 = new PictureBox();
            button1 = new Button();
            dgvPay = new DataGridView();
            timerBlink = new System.Windows.Forms.Timer(components);
            timerAd = new System.Windows.Forms.Timer(components);
            timerRegisterAd = new System.Windows.Forms.Timer(components);
            tabWaitCall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvWait).BeginInit();
            tabRegister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelNew.SuspendLayout();
            grpAgree.SuspendLayout();
            panelMedical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            groupBox1.SuspendLayout();
            panelExisting.SuspendLayout();
            TabPage.SuspendLayout();
            tabHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            tabPay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPay).BeginInit();
            SuspendLayout();
            // 
            // tabWaitCall
            // 
            tabWaitCall.BackColor = Color.White;
            tabWaitCall.Controls.Add(lblAdWait);
            tabWaitCall.Controls.Add(pictureBox2);
            tabWaitCall.Controls.Add(btnHome);
            tabWaitCall.Controls.Add(btnPrescription);
            tabWaitCall.Controls.Add(Waitlist);
            tabWaitCall.Controls.Add(btnComplete);
            tabWaitCall.Controls.Add(btnCall);
            tabWaitCall.Controls.Add(lblWaitTotal);
            tabWaitCall.Controls.Add(lblNowCalling);
            tabWaitCall.Controls.Add(dgvWait);
            tabWaitCall.Location = new Point(4, 27);
            tabWaitCall.Name = "tabWaitCall";
            tabWaitCall.Padding = new Padding(3);
            tabWaitCall.Size = new Size(552, 675);
            tabWaitCall.TabIndex = 1;
            tabWaitCall.Text = "대기 / 호출";
            tabWaitCall.Click += tabWaitCall_Click;
            // 
            // lblAdWait
            // 
            lblAdWait.BackColor = Color.WhiteSmoke;
            lblAdWait.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblAdWait.ForeColor = Color.DarkBlue;
            lblAdWait.Location = new Point(0, 600);
            lblAdWait.Name = "lblAdWait";
            lblAdWait.Size = new Size(542, 45);
            lblAdWait.TabIndex = 9;
            lblAdWait.Text = "광고";
            lblAdWait.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(173, 24);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(170, 90);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // btnHome
            // 
            btnHome.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnHome.Location = new Point(486, 103);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(43, 28);
            btnHome.TabIndex = 7;
            btnHome.Text = "홈";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // btnPrescription
            // 
            btnPrescription.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnPrescription.ForeColor = Color.Brown;
            btnPrescription.Location = new Point(444, 433);
            btnPrescription.Name = "btnPrescription";
            btnPrescription.Size = new Size(85, 30);
            btnPrescription.TabIndex = 6;
            btnPrescription.Text = "처방전 발급";
            btnPrescription.UseVisualStyleBackColor = true;
            btnPrescription.Click += btnPrescription_Click;
            // 
            // Waitlist
            // 
            Waitlist.AutoSize = true;
            Waitlist.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Waitlist.Location = new Point(15, 109);
            Waitlist.Name = "Waitlist";
            Waitlist.Size = new Size(96, 21);
            Waitlist.TabIndex = 5;
            Waitlist.Text = "대기자 목록";
            // 
            // btnComplete
            // 
            btnComplete.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnComplete.Location = new Point(350, 433);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(85, 30);
            btnComplete.TabIndex = 4;
            btnComplete.Text = "진료 완료";
            btnComplete.UseVisualStyleBackColor = true;
            btnComplete.Click += btnComplete_Click;
            // 
            // btnCall
            // 
            btnCall.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnCall.Location = new Point(254, 433);
            btnCall.Name = "btnCall";
            btnCall.Size = new Size(85, 30);
            btnCall.TabIndex = 3;
            btnCall.Text = "호출";
            btnCall.UseVisualStyleBackColor = true;
            btnCall.Click += btnCall_Click;
            // 
            // lblWaitTotal
            // 
            lblWaitTotal.AutoSize = true;
            lblWaitTotal.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblWaitTotal.Location = new Point(15, 443);
            lblWaitTotal.Name = "lblWaitTotal";
            lblWaitTotal.Size = new Size(110, 20);
            lblWaitTotal.TabIndex = 2;
            lblWaitTotal.Text = "전체 대기 : 0명";
            // 
            // lblNowCalling
            // 
            lblNowCalling.AutoSize = true;
            lblNowCalling.BackColor = Color.White;
            lblNowCalling.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNowCalling.Location = new Point(15, 479);
            lblNowCalling.Name = "lblNowCalling";
            lblNowCalling.Size = new Size(103, 21);
            lblNowCalling.TabIndex = 1;
            lblNowCalling.Text = "현재 호출 : -";
            // 
            // dgvWait
            // 
            dgvWait.AllowUserToAddRows = false;
            dgvWait.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWait.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWait.Location = new Point(10, 141);
            dgvWait.MultiSelect = false;
            dgvWait.Name = "dgvWait";
            dgvWait.ReadOnly = true;
            dgvWait.RowHeadersVisible = false;
            dgvWait.RowTemplate.Height = 25;
            dgvWait.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWait.Size = new Size(526, 280);
            dgvWait.TabIndex = 0;
            // 
            // tabRegister
            // 
            tabRegister.BackColor = SystemColors.Window;
            tabRegister.Controls.Add(lbregister);
            tabRegister.Controls.Add(lblAdRegister);
            tabRegister.Controls.Add(pictureBox1);
            tabRegister.Controls.Add(btnHomeRegister);
            tabRegister.Controls.Add(panelNew);
            tabRegister.Controls.Add(panelMedical);
            tabRegister.Controls.Add(groupBox1);
            tabRegister.Location = new Point(4, 27);
            tabRegister.Name = "tabRegister";
            tabRegister.Padding = new Padding(3);
            tabRegister.Size = new Size(552, 675);
            tabRegister.TabIndex = 0;
            tabRegister.Text = "접수";
            // 
            // lbregister
            // 
            lbregister.BackColor = Color.WhiteSmoke;
            lbregister.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lbregister.ForeColor = Color.DarkBlue;
            lbregister.Location = new Point(0, 625);
            lbregister.Name = "lbregister";
            lbregister.Size = new Size(542, 20);
            lbregister.TabIndex = 11;
            lbregister.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAdRegister
            // 
            lblAdRegister.BackColor = Color.WhiteSmoke;
            lblAdRegister.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblAdRegister.ForeColor = Color.DarkBlue;
            lblAdRegister.Location = new Point(0, 600);
            lblAdRegister.Name = "lblAdRegister";
            lblAdRegister.Size = new Size(542, 25);
            lblAdRegister.TabIndex = 11;
            lblAdRegister.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(173, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(170, 90);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // btnHomeRegister
            // 
            btnHomeRegister.Location = new Point(476, 98);
            btnHomeRegister.Name = "btnHomeRegister";
            btnHomeRegister.Size = new Size(43, 29);
            btnHomeRegister.TabIndex = 9;
            btnHomeRegister.Text = "홈";
            btnHomeRegister.UseVisualStyleBackColor = true;
            btnHomeRegister.Click += btnHomeRegister_Click;
            // 
            // panelNew
            // 
            panelNew.Controls.Add(grpAgree);
            panelNew.Controls.Add(txtAddr);
            panelNew.Controls.Add(btnSearchExisting);
            panelNew.Controls.Add(lblAddr);
            panelNew.Controls.Add(btnRegisterNew);
            panelNew.Controls.Add(label5);
            panelNew.Controls.Add(txtName);
            panelNew.Controls.Add(lblPhone);
            panelNew.Controls.Add(txtPhone);
            panelNew.Controls.Add(label3);
            panelNew.Controls.Add(txtBirth);
            panelNew.Location = new Point(15, 243);
            panelNew.Name = "panelNew";
            panelNew.Size = new Size(233, 313);
            panelNew.TabIndex = 6;
            panelNew.Visible = false;
            // 
            // grpAgree
            // 
            grpAgree.Controls.Add(rdoAgreeNo);
            grpAgree.Controls.Add(rdoAgreeYes);
            grpAgree.Location = new Point(0, 191);
            grpAgree.Name = "grpAgree";
            grpAgree.Size = new Size(235, 88);
            grpAgree.TabIndex = 8;
            grpAgree.TabStop = false;
            grpAgree.Text = "개인정보 수집·이용 동의";
            // 
            // rdoAgreeNo
            // 
            rdoAgreeNo.AutoSize = true;
            rdoAgreeNo.Location = new Point(129, 43);
            rdoAgreeNo.Name = "rdoAgreeNo";
            rdoAgreeNo.Size = new Size(61, 19);
            rdoAgreeNo.TabIndex = 7;
            rdoAgreeNo.TabStop = true;
            rdoAgreeNo.Text = "비동의";
            rdoAgreeNo.UseVisualStyleBackColor = true;
            // 
            // rdoAgreeYes
            // 
            rdoAgreeYes.AutoSize = true;
            rdoAgreeYes.Location = new Point(36, 43);
            rdoAgreeYes.Name = "rdoAgreeYes";
            rdoAgreeYes.Size = new Size(49, 19);
            rdoAgreeYes.TabIndex = 6;
            rdoAgreeYes.TabStop = true;
            rdoAgreeYes.Text = "동의";
            rdoAgreeYes.UseVisualStyleBackColor = true;
            // 
            // txtAddr
            // 
            txtAddr.Location = new Point(109, 143);
            txtAddr.Name = "txtAddr";
            txtAddr.Size = new Size(112, 23);
            txtAddr.TabIndex = 5;
            txtAddr.KeyPress += txtAddr_KeyPress;
            // 
            // btnSearchExisting
            // 
            btnSearchExisting.Location = new Point(150, 290);
            btnSearchExisting.Name = "btnSearchExisting";
            btnSearchExisting.Size = new Size(75, 23);
            btnSearchExisting.TabIndex = 8;
            btnSearchExisting.Text = "조회";
            btnSearchExisting.UseVisualStyleBackColor = true;
            btnSearchExisting.Click += btnSearchExisting_Click;
            // 
            // lblAddr
            // 
            lblAddr.AutoSize = true;
            lblAddr.Location = new Point(15, 146);
            lblAddr.Name = "lblAddr";
            lblAddr.Size = new Size(31, 15);
            lblAddr.TabIndex = 3;
            lblAddr.Text = "주소\r";
            // 
            // btnRegisterNew
            // 
            btnRegisterNew.Location = new Point(150, 290);
            btnRegisterNew.Name = "btnRegisterNew";
            btnRegisterNew.Size = new Size(75, 23);
            btnRegisterNew.TabIndex = 2;
            btnRegisterNew.Text = "접수";
            btnRegisterNew.UseVisualStyleBackColor = true;
            btnRegisterNew.Click += btnRegisterNew_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 15);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 1;
            label5.Text = "이름";
            // 
            // txtName
            // 
            txtName.Location = new Point(110, 12);
            txtName.Name = "txtName";
            txtName.Size = new Size(112, 23);
            txtName.TabIndex = 2;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(15, 101);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(55, 15);
            lblPhone.TabIndex = 1;
            lblPhone.Text = "전화번호";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(110, 98);
            txtPhone.MaxLength = 11;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(112, 23);
            txtPhone.TabIndex = 4;
            txtPhone.KeyPress += txtPhone_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 52);
            label3.Name = "label3";
            label3.Size = new Size(83, 30);
            label3.TabIndex = 1;
            label3.Text = "생년월일\r\n(YYYYMMDD)";
            // 
            // txtBirth
            // 
            txtBirth.Location = new Point(110, 52);
            txtBirth.MaxLength = 8;
            txtBirth.Name = "txtBirth";
            txtBirth.Size = new Size(112, 23);
            txtBirth.TabIndex = 3;
            txtBirth.KeyPress += txtBirth_KeyPress;
            // 
            // panelMedical
            // 
            panelMedical.BackColor = Color.White;
            panelMedical.Controls.Add(pictureBox3);
            panelMedical.Controls.Add(label1);
            panelMedical.Controls.Add(cmbDept);
            panelMedical.Controls.Add(label2);
            panelMedical.Controls.Add(clbSymptoms);
            panelMedical.Controls.Add(btnSubmit);
            panelMedical.Location = new Point(261, 135);
            panelMedical.Name = "panelMedical";
            panelMedical.Size = new Size(262, 431);
            panelMedical.TabIndex = 7;
            panelMedical.Visible = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(3, 367);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(51, 53);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(11, 29);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 0;
            label1.Text = "진료과";
            // 
            // cmbDept
            // 
            cmbDept.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDept.Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            cmbDept.FormattingEnabled = true;
            cmbDept.Items.AddRange(new object[] { "내과", "외과", "정형외과", "피부과", "치과" });
            cmbDept.Location = new Point(82, 26);
            cmbDept.Name = "cmbDept";
            cmbDept.Size = new Size(169, 25);
            cmbDept.TabIndex = 0;
            cmbDept.SelectedIndexChanged += cmbDept_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(16, 98);
            label2.Name = "label2";
            label2.Size = new Size(154, 20);
            label2.TabIndex = 2;
            label2.Text = "증상 선택 (복수 선택)";
            // 
            // clbSymptoms
            // 
            clbSymptoms.CheckOnClick = true;
            clbSymptoms.Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            clbSymptoms.FormattingEnabled = true;
            clbSymptoms.Location = new Point(22, 124);
            clbSymptoms.Name = "clbSymptoms";
            clbSymptoms.Size = new Size(211, 224);
            clbSymptoms.TabIndex = 0;
            // 
            // btnSubmit
            // 
            btnSubmit.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnSubmit.Location = new Point(175, 368);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(70, 25);
            btnSubmit.TabIndex = 0;
            btnSubmit.Text = "접수";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdoExisting);
            groupBox1.Controls.Add(rdoNew);
            groupBox1.Controls.Add(panelExisting);
            groupBox1.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(17, 135);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(223, 95);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "접수 유형";
            // 
            // rdoExisting
            // 
            rdoExisting.AutoSize = true;
            rdoExisting.Location = new Point(130, 44);
            rdoExisting.Name = "rdoExisting";
            rdoExisting.Size = new Size(52, 21);
            rdoExisting.TabIndex = 1;
            rdoExisting.TabStop = true;
            rdoExisting.Text = "기존";
            rdoExisting.UseVisualStyleBackColor = true;
            rdoExisting.CheckedChanged += rdoExisting_CheckedChanged;
            // 
            // rdoNew
            // 
            rdoNew.AutoSize = true;
            rdoNew.Location = new Point(37, 44);
            rdoNew.Name = "rdoNew";
            rdoNew.Size = new Size(52, 21);
            rdoNew.TabIndex = 0;
            rdoNew.TabStop = true;
            rdoNew.Text = "신규";
            rdoNew.UseVisualStyleBackColor = true;
            rdoNew.CheckedChanged += rdoNew_CheckedChanged;
            // 
            // panelExisting
            // 
            panelExisting.Controls.Add(txtExName);
            panelExisting.Controls.Add(textBox2);
            panelExisting.Controls.Add(textBox1);
            panelExisting.Controls.Add(txtExBirth);
            panelExisting.Location = new Point(92, 121);
            panelExisting.Name = "panelExisting";
            panelExisting.Size = new Size(235, 165);
            panelExisting.TabIndex = 2;
            panelExisting.Visible = false;
            // 
            // txtExName
            // 
            txtExName.AutoSize = true;
            txtExName.Location = new Point(15, 15);
            txtExName.Name = "txtExName";
            txtExName.Size = new Size(34, 17);
            txtExName.TabIndex = 1;
            txtExName.Text = "이름";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(106, 12);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 25);
            textBox2.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(106, 52);
            textBox1.MaxLength = 8;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 25);
            textBox1.TabIndex = 0;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // txtExBirth
            // 
            txtExBirth.AutoSize = true;
            txtExBirth.Location = new Point(15, 52);
            txtExBirth.Name = "txtExBirth";
            txtExBirth.Size = new Size(96, 34);
            txtExBirth.TabIndex = 1;
            txtExBirth.Text = "생년월일\r\n(YYYYMMDD)";
            // 
            // TabPage
            // 
            TabPage.Appearance = TabAppearance.FlatButtons;
            TabPage.Controls.Add(tabHome);
            TabPage.Controls.Add(tabRegister);
            TabPage.Controls.Add(tabWaitCall);
            TabPage.Controls.Add(tabPay);
            TabPage.Dock = DockStyle.Fill;
            TabPage.Location = new Point(0, 0);
            TabPage.Name = "TabPage";
            TabPage.SelectedIndex = 0;
            TabPage.Size = new Size(560, 706);
            TabPage.SizeMode = TabSizeMode.Fixed;
            TabPage.TabIndex = 0;
            // 
            // tabHome
            // 
            tabHome.AutoScroll = true;
            tabHome.BackColor = Color.White;
            tabHome.BackgroundImage = (Image)resources.GetObject("tabHome.BackgroundImage");
            tabHome.BackgroundImageLayout = ImageLayout.Zoom;
            tabHome.Controls.Add(pictureBox9);
            tabHome.Controls.Add(pictureBox8);
            tabHome.Controls.Add(label6);
            tabHome.Controls.Add(label4);
            tabHome.Controls.Add(lblWaitRegister);
            tabHome.Controls.Add(btnGoRegister);
            tabHome.Controls.Add(pictureBox6);
            tabHome.Controls.Add(lblWaitPay);
            tabHome.Controls.Add(btnGoPay);
            tabHome.Controls.Add(lbHomeSmall);
            tabHome.Controls.Add(lbHomeBig);
            tabHome.Location = new Point(4, 27);
            tabHome.Name = "tabHome";
            tabHome.Size = new Size(552, 675);
            tabHome.TabIndex = 2;
            tabHome.Text = "홈";
            // 
            // pictureBox9
            // 
            pictureBox9.BackColor = Color.AliceBlue;
            pictureBox9.Image = (Image)resources.GetObject("pictureBox9.Image");
            pictureBox9.Location = new Point(303, 363);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(145, 103);
            pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox9.TabIndex = 9;
            pictureBox9.TabStop = false;
            pictureBox9.Click += pictureBox9_Click;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = Color.AliceBlue;
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(82, 363);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(150, 103);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 8;
            pictureBox8.TabStop = false;
            pictureBox8.Click += pictureBox8_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.AliceBlue;
            label6.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(348, 473);
            label6.Name = "label6";
            label6.Size = new Size(55, 30);
            label6.TabIndex = 7;
            label6.Text = "수납";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.AliceBlue;
            label4.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(128, 473);
            label4.Name = "label4";
            label4.Size = new Size(55, 30);
            label4.TabIndex = 7;
            label4.Text = "접수";
            // 
            // lblWaitRegister
            // 
            lblWaitRegister.AutoSize = true;
            lblWaitRegister.BackColor = Color.AliceBlue;
            lblWaitRegister.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblWaitRegister.Location = new Point(112, 512);
            lblWaitRegister.Name = "lblWaitRegister";
            lblWaitRegister.Size = new Size(86, 17);
            lblWaitRegister.TabIndex = 1;
            lblWaitRegister.Text = "대기인원 0명";
            // 
            // btnGoRegister
            // 
            btnGoRegister.BackColor = Color.AliceBlue;
            btnGoRegister.FlatAppearance.BorderSize = 2;
            btnGoRegister.FlatStyle = FlatStyle.Popup;
            btnGoRegister.Font = new Font("맑은 고딕", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btnGoRegister.ForeColor = Color.Thistle;
            btnGoRegister.Location = new Point(78, 353);
            btnGoRegister.Name = "btnGoRegister";
            btnGoRegister.Size = new Size(158, 183);
            btnGoRegister.TabIndex = 0;
            btnGoRegister.UseVisualStyleBackColor = false;
            btnGoRegister.Click += btnGoRegister_Click;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(176, 25);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(175, 95);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 6;
            pictureBox6.TabStop = false;
            // 
            // lblWaitPay
            // 
            lblWaitPay.AutoSize = true;
            lblWaitPay.BackColor = Color.AliceBlue;
            lblWaitPay.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblWaitPay.Location = new Point(333, 512);
            lblWaitPay.Name = "lblWaitPay";
            lblWaitPay.Size = new Size(86, 17);
            lblWaitPay.TabIndex = 1;
            lblWaitPay.Text = "대기인원 0명";
            lblWaitPay.Click += lblWaitPay_Click;
            // 
            // btnGoPay
            // 
            btnGoPay.BackColor = Color.AliceBlue;
            btnGoPay.FlatAppearance.BorderSize = 2;
            btnGoPay.FlatStyle = FlatStyle.Popup;
            btnGoPay.Font = new Font("맑은 고딕", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btnGoPay.ForeColor = Color.Thistle;
            btnGoPay.Location = new Point(296, 353);
            btnGoPay.Name = "btnGoPay";
            btnGoPay.Size = new Size(158, 183);
            btnGoPay.TabIndex = 0;
            btnGoPay.UseVisualStyleBackColor = false;
            btnGoPay.Click += btnGoPay_Click;
            // 
            // lbHomeSmall
            // 
            lbHomeSmall.AutoSize = true;
            lbHomeSmall.BackColor = Color.LightSteelBlue;
            lbHomeSmall.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbHomeSmall.Location = new Point(75, 318);
            lbHomeSmall.Name = "lbHomeSmall";
            lbHomeSmall.Size = new Size(235, 21);
            lbHomeSmall.TabIndex = 1;
            lbHomeSmall.Text = "원하시는 업무를 선택해주세요!";
            // 
            // lbHomeBig
            // 
            lbHomeBig.AutoSize = true;
            lbHomeBig.BackColor = Color.Transparent;
            lbHomeBig.Font = new Font("맑은 고딕", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lbHomeBig.Location = new Point(117, 182);
            lbHomeBig.Name = "lbHomeBig";
            lbHomeBig.Size = new Size(305, 32);
            lbHomeBig.TabIndex = 2;
            lbHomeBig.Text = "여기에서 접수/수납하세요!";
            lbHomeBig.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabPay
            // 
            tabPay.BackColor = Color.White;
            tabPay.Controls.Add(lblAdPay);
            tabPay.Controls.Add(label7);
            tabPay.Controls.Add(pictureBox7);
            tabPay.Controls.Add(btnReset);
            tabPay.Controls.Add(pictureBox5);
            tabPay.Controls.Add(button1);
            tabPay.Controls.Add(dgvPay);
            tabPay.Location = new Point(4, 27);
            tabPay.Name = "tabPay";
            tabPay.Padding = new Padding(3);
            tabPay.Size = new Size(552, 675);
            tabPay.TabIndex = 3;
            tabPay.Text = "수납";
            // 
            // lblAdPay
            // 
            lblAdPay.BackColor = Color.WhiteSmoke;
            lblAdPay.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblAdPay.ForeColor = Color.DarkBlue;
            lblAdPay.Location = new Point(0, 600);
            lblAdPay.Name = "lblAdPay";
            lblAdPay.Size = new Size(542, 45);
            lblAdPay.TabIndex = 7;
            lblAdPay.Text = "광고";
            lblAdPay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(16, 148);
            label7.Name = "label7";
            label7.Size = new Size(96, 21);
            label7.TabIndex = 6;
            label7.Text = "수납 대기자";
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(173, 24);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(170, 90);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 5;
            pictureBox7.TabStop = false;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnReset.Location = new Point(480, 145);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(46, 27);
            btnReset.TabIndex = 4;
            btnReset.Text = "홈";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(3, 462);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(39, 45);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 3;
            pictureBox5.TabStop = false;
            // 
            // button1
            // 
            button1.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(443, 492);
            button1.Name = "button1";
            button1.Size = new Size(83, 30);
            button1.TabIndex = 1;
            button1.Text = "결제";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dgvPay
            // 
            dgvPay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPay.Location = new Point(8, 181);
            dgvPay.Name = "dgvPay";
            dgvPay.RowTemplate.Height = 25;
            dgvPay.Size = new Size(526, 305);
            dgvPay.TabIndex = 0;
            // 
            // timerBlink
            // 
            timerBlink.Enabled = true;
            timerBlink.Interval = 500;
            timerBlink.Tick += timerBlink_Tick;
            // 
            // timerAd
            // 
            timerAd.Enabled = true;
            timerAd.Interval = 1200;
            timerAd.Tick += timerAd_Tick;
            // 
            // timerRegisterAd
            // 
            timerRegisterAd.Enabled = true;
            timerRegisterAd.Interval = 900;
            timerRegisterAd.Tick += timerRegisterAd_Tick;
            // 
            // tabMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(560, 706);
            Controls.Add(TabPage);
            Name = "tabMain";
            StartPosition = FormStartPosition.Manual;
            Text = "병원 키오스크";
            Load += Form1_Load;
            Shown += Form1_Shown;
            Resize += tabMain_Resize;
            tabWaitCall.ResumeLayout(false);
            tabWaitCall.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvWait).EndInit();
            tabRegister.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelNew.ResumeLayout(false);
            panelNew.PerformLayout();
            grpAgree.ResumeLayout(false);
            grpAgree.PerformLayout();
            panelMedical.ResumeLayout(false);
            panelMedical.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panelExisting.ResumeLayout(false);
            panelExisting.PerformLayout();
            TabPage.ResumeLayout(false);
            tabHome.ResumeLayout(false);
            tabHome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            tabPay.ResumeLayout(false);
            tabPay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPay).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabPage tabWaitCall;
        private TabPage tabRegister;
        private CheckedListBox clbSymptoms;
        private Label label2;
        private ComboBox cmbDept;
        private Label label1;
        private TabControl TabPage;
        private TabPage tabHome;
        private Label lbHomeSmall;
        private Label lbHomeBig;
        private Button btnGoRegister;
        private Label lblWaitPay;
        private Button btnGoPay;
        private Button btnSubmit;
        private GroupBox groupBox1;
        private RadioButton rdoExisting;
        private RadioButton rdoNew;
        private Panel panelExisting;
        private Panel panelNew;
        private TextBox txtBirth;
        private Label label5;
        private TextBox txtName;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label label3;
        private Label txtExName;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label txtExBirth;
        private Button btnRegisterNew;
        private Button btnSearchExisting;
        private Panel panelMedical;
        private Label lblWaitTotal;
        private Label lblNowCalling;
        private DataGridView dgvWait;
        private Button btnComplete;
        private Button btnCall;
        private Label Waitlist;
        private TextBox txtAddr;
        private Label lblAddr;
        private GroupBox grpAgree;
        private RadioButton rdoAgreeNo;
        private RadioButton rdoAgreeYes;
        private Button btnPrescription;
        private TabPage tabPay;
        private DataGridView dgvPay;
        private Button btnHome;
        private Button button1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox5;
        private Button btnReset;
        private Button btnHomeRegister;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox7;
        private Label lblWaitRegister;
        private PictureBox pictureBox6;
        private System.Windows.Forms.Timer timerBlink;
        private Label label4;
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
        private Label label6;
        private Label label7;
        private Label lblAdWait;
        private System.Windows.Forms.Timer timerAd;
        private Label lblAdRegister;
        private Label lblAdPay;
        private System.Windows.Forms.Timer timerRegisterAd;
        private Label lbregister;
    }
}
