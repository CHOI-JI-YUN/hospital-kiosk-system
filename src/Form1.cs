using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Kiosk
{
    public partial class tabMain : Form
    {
        private bool blinkOn = false;
        //진료과별 증상 목록
        private Dictionary<string, List<string>> deptSymptoms = new Dictionary<string, List<string>>();

        //진료과별 대기열
        private Dictionary<string, Queue<string>> deptQueues = new Dictionary<string, Queue<string>>();

        //대기번호
        private int nextNumber = 1;

        private Dictionary<(string Name, string Birth), string> patientDb = new Dictionary<(string Name, string Birth), string>();

        private bool isPatientVerified = false;   // 조회/등록 성공 여부
        private string verifiedName = "";
        private string verifiedBirth = "";
        private string currentCallMessage = "현재 호출 : -";

        private BindingList<WaitItem> waitList = new BindingList<WaitItem>();
        private WaitItem currentCalling = null;

        // 수납 탭에 보여줄 리스트
        private BindingList<WaitItem> payList = new BindingList<WaitItem>();
        private BindingSource paySource = new BindingSource();
        private void UpdateRegisterTypeUI()
        {
            lblWaitTotal.Text = $"전체 대기 : {waitList.Count}명";
            lblNowCalling.Text = currentCallMessage;
        }

        private void UpdatePayCount()
        {
            lblWaitPay.Text = $"대기인원 {payList.Count}명";
        }

        public tabMain()
        {
            InitializeComponent();
        }
        // 접수 전광판 문자열
        private string registerAdText;

        // 안내문 인덱스
        private int noticeIndex = 0;

        // 접수 광고
        private string[] registerAds =
        {
            "정확한 접수를 위해 개인정보를 확인해 주세요.",
            "우리들병원은 환자 중심의 진료 서비스를 제공합니다.",
        };

        // 대기 광고
        private string[] waitAds =
        {
            "진료 순서에 따라 호출됩니다. 잠시만 기다려 주세요.",
            "호출 시 자리를 비우면 다음 순서로 넘어갈 수 있습니다.",
            "우리들병원 척추·관절 전문 진료"
        };

        // 수납 광고
        private string[] payAds =
        {
            "수납 및 제증명 문의는 창구를 이용해 주세요.",
            "결제 시스템 점검 시 창구에서 수납 가능합니다.",
            "우리들병원은 정확하고 친절한 진료를 제공합니다."
        };

        //private void tabMain_Click(object sender, EventArgs e)
        //{

        //}

        private void AdjustWaitTabLayout()
        {
            int gridLeft = 12;
            int gridTop = 95;
            int gridWidth = this.ClientSize.Width - 24;
            int gridHeight = 300;

            // 대기/호출 탭
            dgvWait.Location = new Point(gridLeft, gridTop);
            dgvWait.Size = new Size(gridWidth, gridHeight);

            lblWaitTotal.Location = new Point(15, gridTop + gridHeight + 20);
            lblNowCalling.Location = new Point(15, gridTop + gridHeight + 55);

            btnCall.Location = new Point(this.ClientSize.Width - 180, gridTop + gridHeight + 15);
            btnComplete.Location = new Point(this.ClientSize.Width - 90, gridTop + gridHeight + 15);
            btnPrescription.Location = new Point(this.ClientSize.Width - 180, gridTop + gridHeight + 50);

            btnHome.Location = new Point(this.ClientSize.Width - 55, 10);
        }

        private void AdjustPayTabLayout()
        {
            int gridLeft = 12;
            int gridTop = 45;
            int gridWidth = this.ClientSize.Width - 24;
            int gridHeight = 310;

            // 수납 탭
            dgvPay.Location = new Point(gridLeft, gridTop);
            dgvPay.Size = new Size(gridWidth, gridHeight);

            button1.Location = new Point(this.ClientSize.Width - 95, gridTop + gridHeight + 15); // 결제 버튼
            btnHomeRegister.Location = new Point(this.ClientSize.Width - 55, 10); // 수납 탭 홈버튼 이름이 다르면 바꿔
        }

        private readonly Dictionary<string, int> deptRoom = new Dictionary<string, int>
        {
            { "내과", 1 },
            { "외과", 2 },
            { "정형외과", 3 },
            { "피부과", 4 },
            { "치과", 5 }
        };

        private readonly Dictionary<string, List<string>> symptomPrescriptionMap = new Dictionary<string, List<string>>
        {
            { "발열", new List<string> { "타이레놀", "이부프로펜" } },
            { "기침", new List<string> { "코푸시럽", "덱스트로메토르판" } },
            { "복통", new List<string> { "부스코판", "트리메부틴" } },
            { "인후통", new List<string> { "트로키", "목 스프레이" } },
            { "두통", new List<string> { "타이레놀", "게보린" } },
            { "설사", new List<string> { "정로환", "로페라마이드" } },
            { "구토", new List<string> { "맥페란", "돔페리돈" } },
            { "어지럼", new List<string> { "메니에르정", "베타히스틴" } },
            { "치통", new List<string> { "이부프로펜", "항생제" } },
            { "무릎 통증", new List<string> { "소염진통제", "파스" } }
        };
        private void MakeButtonRounded(Button btn)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 40;

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            btn.Region = new Region(path);
        }


        //수납
        private readonly Dictionary<string, int> deptFee = new Dictionary<string, int>
        {
            { "내과", 15000 },
            { "외과", 20000 },
            { "정형외과", 25000 },
            { "피부과", 18000 },
            { "치과", 30000 }
        };



        private void Form1_Load(object sender, EventArgs e)
        {
            btnGoRegister.FlatStyle = FlatStyle.Flat;
            btnGoPay.FlatStyle = FlatStyle.Flat;

            btnGoRegister.FlatAppearance.BorderColor = Color.FromArgb(70, 130, 180);
            btnGoPay.FlatAppearance.BorderColor = Color.FromArgb(70, 130, 180);

            btnGoRegister.FlatAppearance.BorderSize = 3;
            btnGoPay.FlatAppearance.BorderSize = 3;

            // 1) 진료과별 증상 세팅
            deptSymptoms["내과"] = new List<string> { "발열", "기침", "가래", "인후통", "두통", "복통", "설사", "구토", "어지럼" };
            deptSymptoms["외과"] = new List<string> { "상처", "출혈", "찢어짐", "화상", "봉합 필요", "고름/종기" };
            deptSymptoms["정형외과"] = new List<string> { "허리 통증", "목 통증", "어깨 통증", "무릎 통증", "염좌(삠)", "골절 의심", "부기" };
            deptSymptoms["피부과"] = new List<string> { "가려움", "발진", "두드러기", "여드름", "습진", "알레르기" };
            deptSymptoms["치과"] = new List<string> { "치통", "충치 의심", "잇몸 통증", "사랑니 통증", "시린 이" };

            foreach (var dept in deptSymptoms.Keys)
            {
                if (!deptQueues.ContainsKey(dept))
                    deptQueues[dept] = new Queue<string>();
            }

            // 2) 기본 UI 세팅
            if (cmbDept.Items.Count > 0)
                cmbDept.SelectedIndex = 0;

            TabPage.Appearance = TabAppearance.FlatButtons;
            TabPage.ItemSize = new System.Drawing.Size(0, 1);
            TabPage.SizeMode = TabSizeMode.Fixed;
            TabPage.SelectedTab = tabHome;

            rdoNew.Checked = false;
            rdoExisting.Checked = false;
            panelNew.Visible = false;
            panelExisting.Visible = false;

            rdoAgreeYes.Checked = false;
            rdoAgreeNo.Checked = false;

            // 3) 대기 목록(DataGridView) 세팅
            dgvWait.AutoGenerateColumns = false;
            dgvWait.Columns.Clear();

            dgvWait.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWait.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvWait.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvWait.ColumnHeadersHeight = 28;

            dgvWait.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "번호",
                DataPropertyName = "Number",
                FillWeight = 8
            });

            dgvWait.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "진료실",
                DataPropertyName = "Room",
                FillWeight = 10
            });

            dgvWait.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "진료과",
                DataPropertyName = "Dept",
                FillWeight = 12
            });

            dgvWait.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "이름",
                DataPropertyName = "Name",
                FillWeight = 14
            });

            dgvWait.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "증상",
                DataPropertyName = "Symptoms",
                FillWeight = 26
            });

            dgvWait.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "시간",
                DataPropertyName = "Time",
                FillWeight = 25,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "HH:mm" }
            });

            dgvWait.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "상태",
                DataPropertyName = "Status",
                FillWeight = 12
            });

            dgvWait.DataSource = waitList;

            //수납(번호/진료과/이름/시간만)
            dgvPay.AutoGenerateColumns = false;
            dgvPay.Columns.Clear();

            dgvPay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPay.MultiSelect = false;
            dgvPay.ReadOnly = true;
            dgvPay.AllowUserToAddRows = false;
            dgvPay.RowHeadersVisible = false;

            dgvPay.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "번호",
                DataPropertyName = "Number",
                FillWeight = 20
            });
            dgvPay.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "진료과",
                DataPropertyName = "Dept",
                FillWeight = 40
            });
            dgvPay.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "이름",
                DataPropertyName = "Name",
                FillWeight = 40
            });
            dgvPay.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "시간",
                DataPropertyName = "Time",
                FillWeight = 40,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "HH:mm" }
            });

            // ===== 바인딩 =====
            paySource.DataSource = payList;
            dgvPay.DataSource = paySource;

            // 4) 랜덤 대기 데이터 생성
            nextNumber = 1;
            SeedRandomWaitList();

            // 5) 라벨 갱신
            UpdateHomeWaitCount();
            UpdateWaitCallUI();
            UpdatePayCount();

            MakeButtonRounded(btnGoRegister);
            MakeButtonRounded(btnGoPay);

            payList.ListChanged += (s, e) => UpdateHomePayCount();
            UpdateHomePayCount();

            // 대기/호출 탭 배치
            Waitlist.Location = new Point(10, 115);   // "대기자 목록" 라벨 이름에 맞게 바꿔
            Waitlist.AutoSize = true;

            btnHome.Location = new Point(487, 108);
            btnHome.Size = new Size(45, 28);

            dgvWait.Location = new Point(3, 145);
            dgvWait.Size = new Size(527, 277);

            lblWaitTotal.Location = new Point(10, 440);
            lblWaitTotal.AutoSize = true;

            lblNowCalling.Location = new Point(10, 470);
            lblNowCalling.AutoSize = true;


            // 접수 전광판 문자열 생성
            registerAdText =
                "     " +
                string.Join("     ", registerAds) +
                "     " +
                string.Join("     ", registerAds) +
                "     ";

            lblAdRegister.Text = registerAdText;

            // 대기 / 수납 첫 문장
            lblAdWait.Text = waitAds[0];
            lblAdPay.Text = payAds[0];
        }


        private void UpdateHomePayCount()
        {
            lblWaitPay.Text = $"대기인원 {payList.Count}명";
        }

        private void ApplyRoundButton(Button btn, int radius = 40)
        {
            // 기본 버튼 테마/테두리 제거
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.UseVisualStyleBackColor = false;

            // (중요) Paint가 중복으로 붙지 않게
            btn.Paint -= RoundButton_Paint;
            btn.Paint += RoundButton_Paint;

            // 크기 바뀔 때도 다시 그리기
            btn.Resize -= RoundButton_Resize;
            btn.Resize += RoundButton_Resize;

            // 처음 한 번 강제 리프레시
            btn.Invalidate();
        }

        private void RoundButton_Resize(object? sender, EventArgs e)
        {
            if (sender is Button b) b.Invalidate();
        }

        private void RoundButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Button b) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(b.Parent.BackColor);

            int radius = 40;

            Rectangle rect = new Rectangle(0, 0, b.Width - 1, b.Height - 1);

            using (GraphicsPath path = new GraphicsPath())
            {
                int r = radius;
                path.AddArc(rect.X, rect.Y, r, r, 180, 90);
                path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
                path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
                path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
                path.CloseFigure();

                b.Region = new Region(path);

                using (SolidBrush br = new SolidBrush(b.BackColor))
                    e.Graphics.FillPath(br, path);

                using (Pen pen = new Pen(Color.Black, 2))
                    e.Graphics.DrawPath(pen, path);
            }

            TextRenderer.DrawText(
                e.Graphics,
                b.Text,
                b.Font,
                rect,
                b.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }

        private void UpdateWaitCallUI()
        {
            int waitingCount = waitList.Count(w => w.Status == "대기");
            lblWaitTotal.Text = $"전체 대기 : {waitingCount}명";
            lblNowCalling.Text = currentCallMessage;
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dept = cmbDept.Text;

            clbSymptoms.Items.Clear();

            if (!deptSymptoms.ContainsKey(dept))
                return;

            foreach (var s in deptSymptoms[dept])
                clbSymptoms.Items.Add(s);
        }

        private void btnGoRegister_Click(object sender, EventArgs e)
        {
            TabPage.SelectedTab = tabRegister;

            // 2단계(진료과/증상) 숨김
            isPatientVerified = false;
            verifiedName = "";
            verifiedBirth = "";
            panelMedical.Visible = false;

            // 유형 선택도 처음엔 숨김/해제
            rdoNew.Checked = false;
            rdoExisting.Checked = false;
            panelNew.Visible = false;
            panelExisting.Visible = false;

            rdoAgreeYes.Checked = false;
            rdoAgreeNo.Checked = false;
        }

        private void btnGoPay_Click(object sender, EventArgs e)
        {
            TabPage.SelectedTab = tabPay;
        }

        private void UpdateHomeWaitCount()
        {
            lblWaitRegister.Text = $"대기인수 {waitList.Count}명";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!isPatientVerified)
            {
                KioskMessageBox.Show(this, "먼저 신규 접수 또는 기존 조회를 완료하세요.");
                return;
            }

            if (!rdoAgreeYes.Checked && !rdoAgreeNo.Checked)
            {
                KioskMessageBox.Show(this, "개인정보 수집·이용 동의 여부를 선택하세요.");
                return;
            }

            if (rdoAgreeNo.Checked)
            {
                KioskMessageBox.Show(this, "개인정보 수집·이용에 동의해야 접수가 가능합니다.");
                return;
            }

            var selected = clbSymptoms.CheckedItems
                .Cast<object>()
                .Select(x => x.ToString())
                .ToList();

            if (selected.Count == 0)
            {
                KioskMessageBox.Show(this, "증상을 선택하세요.");
                return;
            }

            string dept = cmbDept.Text;
            string symptomText = string.Join(", ", selected);

            int room = deptRoom.ContainsKey(dept) ? deptRoom[dept] : 0;

            var item = new WaitItem
            {
                Number = nextNumber++,
                Room = room,
                Dept = dept,
                Name = verifiedName,
                Birth = verifiedBirth,
                Symptoms = symptomText,
                Time = DateTime.Now
            };

            waitList.Add(item);

            UpdateHomeWaitCount();
            UpdateWaitCallUI();

            KioskMessageBox.Show(this, "접수 완료!");
            TabPage.SelectedTab = tabWaitCall;

        }

        private void rdoNew_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdoNew.Checked) return;

            panelNew.Visible = true;
            panelNew.BringToFront();

            txtPhone.Visible = true;
            txtAddr.Visible = true;

            lblPhone.Visible = true;
            lblAddr.Visible = true;

            btnRegisterNew.Visible = true;
            btnSearchExisting.Visible = false;
        }

        private void rdoExisting_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdoExisting.Checked) return;

            panelNew.Visible = true;
            panelNew.BringToFront();

            txtPhone.Visible = false;
            txtAddr.Visible = false;

            lblPhone.Visible = false;
            lblAddr.Visible = false;

            btnRegisterNew.Visible = false;
            btnSearchExisting.Visible = true;
            btnSearchExisting.BringToFront();
        }



        private void btnRegisterNew_Click(object sender, EventArgs e)
        {
            if (!rdoAgreeYes.Checked && !rdoAgreeNo.Checked)
            {
                KioskMessageBox.Show(this, "개인정보 수집·이용 동의 여부를 선택하세요.");
                return;
            }
            if (rdoAgreeNo.Checked)
            {
                KioskMessageBox.Show(this, "개인정보 수집·이용에 동의해야 접수가 가능합니다.");
                return;
            }

            string name = txtName.Text.Trim();
            string birth = txtBirth.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string addr = txtAddr.Text.Trim();

            if (name == "")
            {
                KioskMessageBox.Show(this, "이름을 입력하세요.");
                txtName.Focus();
                return;
            }
            if (birth == "")
            {
                KioskMessageBox.Show(this, "생년월일을 입력하세요.");
                txtBirth.Focus();
                return;
            }
            if (phone == "")
            {
                KioskMessageBox.Show(this, "전화번호를 입력하세요.");
                txtPhone.Focus();
                return;
            }
            if (addr == "")
            {
                KioskMessageBox.Show(this, "주소를 입력하세요.");
                txtAddr.Focus();
                return;
            }

            var key = (name, birth);
            if (patientDb.ContainsKey(key))
            {
                KioskMessageBox.Show(this, "이미 등록된 정보가 있습니다. 기존 조회를 이용하세요.");
                return;
            }

            patientDb[key] = phone;

            KioskMessageBox.Show(this, "접수(등록)되었습니다.");

            isPatientVerified = true;
            verifiedName = name;
            verifiedBirth = birth;

            panelMedical.Visible = true;
            panelMedical.BringToFront();

        }

        private void btnSearchExisting_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string birth = txtBirth.Text.Trim();

            if (name == "" || birth == "")
            {
                KioskMessageBox.Show(this, "이름과 생년월일을 입력하세요.");
                return;
            }

            if (!patientDb.ContainsKey((name, birth)))
            {
                KioskMessageBox.Show(this, "조회 결과가 없습니다. 신규 등록을 해주세요.");
                return;
            }

            KioskMessageBox.Show(this, "조회되었습니다.");

            isPatientVerified = true;
            verifiedName = name;
            verifiedBirth = birth;

            panelMedical.Visible = true;
            panelMedical.BringToFront();
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            if (dgvWait.CurrentRow == null)
            {
                KioskMessageBox.Show(this, "호출할 환자를 선택하세요.");
                return;
            }

            var item = dgvWait.CurrentRow.DataBoundItem as WaitItem;
            if (item == null) return;

            if (item.Status == "진료중")
            {
                KioskMessageBox.Show(this, "이미 진료중인 환자입니다.");
                return;
            }

            // 현재 진료중인 환자가 있으면 막기
            if (currentCalling != null)
            {
                KioskMessageBox.Show(this, "현재 진료중인 환자가 있습니다.\n먼저 [진료 완료]를 진행하세요.");
                return;
            }

            //현재 진료중(호출된) 환자 저장
            currentCalling = item;

            // 상태를 "진료중"으로 변경
            item.Status = "진료중";

            // 팝업: 들어오세요
            KioskMessageBox.Show(this, $"{item.Name}님 / {item.Room}번 진료실로 들어오세요!");

            // 아래 상태: 진료중 (유지)
            currentCallMessage = $"{item.Name}님 / {item.Room}번 진료실 - 진료중";

            // DataGridView 갱신 (상태 컬럼 반영)
            dgvWait.Refresh();

            // "진료중" 행 색상 변경
            foreach (DataGridViewRow row in dgvWait.Rows)
            {
                var w = row.DataBoundItem as WaitItem;
                if (w != null && w.Status == "진료중")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200);
                    row.DefaultCellStyle.ForeColor = Color.OrangeRed;
                    row.DefaultCellStyle.Font = new Font("맑은 고딕", 9, FontStyle.Bold);
                }
            }

            // UI 갱신
            UpdateHomeWaitCount();
            UpdateWaitCallUI();
        }

        private void SeedRandomWaitList(int minCount = 3, int maxCount = 7)
        {
            var rnd = new Random();

            string[] depts = { "내과", "외과", "정형외과", "피부과", "치과" };
            string[] names = { "최현욱", "이도현", "김재원", "고윤정", "노윤서", "한소희", "김선호", "신세경" };
            string[] symptoms = { "발열", "기침", "복통", "두통", "가려움", "치통", "어지럼", "상처", "무릎 통증" };

            int count = rnd.Next(minCount, maxCount + 1);
            count = Math.Min(count, names.Length);

            waitList.Clear();

            HashSet<string> usedNames = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                string dept = depts[rnd.Next(depts.Length)];
                int room = deptRoom.ContainsKey(dept) ? deptRoom[dept] : rnd.Next(1, 6);

                string name;
                do
                {
                    name = names[rnd.Next(names.Length)];
                } while (!usedNames.Add(name));

                string birth = $"{rnd.Next(1985, 2006)}{rnd.Next(1, 13):D2}{rnd.Next(1, 29):D2}";
                string symptomText = $"{symptoms[rnd.Next(symptoms.Length)]}, {symptoms[rnd.Next(symptoms.Length)]}";

                waitList.Add(new WaitItem
                {
                    Number = nextNumber++,
                    Room = room,
                    Dept = dept,
                    Name = name,
                    Birth = birth,
                    Symptoms = symptomText,
                    Time = DateTime.Now.AddMinutes(-rnd.Next(1, 60))
                });
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (currentCalling == null)
            {
                KioskMessageBox.Show(this, "먼저 [호출]을 진행하세요.");
                return;
            }

            var item = currentCalling;

            KioskMessageBox.Show(this, $"{item.Name}님 진료 완료되었습니다.");

            // 대기 목록에서 제거
            waitList.Remove(item);

            if (!payList.Contains(item))
                payList.Add(item);

            paySource.ResetBindings(false);
            UpdateHomePayCount();
            UpdatePayCount();

            KioskMessageBox.Show(this, $"{item.Name}님 수납 대기입니다.");

            currentCalling = null;
            currentCallMessage = "현재 호출: -";

            UpdateHomeWaitCount();
            UpdateWaitCallUI();
        }

        private bool CheckPrivacyAgreement()
        {
            if (!rdoAgreeYes.Checked && !rdoAgreeNo.Checked)
            {
                KioskMessageBox.Show(this, "개인정보 수집·이용 동의 여부를 선택하세요.");
                return false;
            }

            if (rdoAgreeNo.Checked)
            {
                KioskMessageBox.Show(this, "개인정보 수집·이용에 동의해야 접수가 가능합니다.");
                return false;
            }

            return true;
        }

        private void btnPrescription_Click(object sender, EventArgs e)
        {
            WaitItem target = null;

            if (payList.Count > 0)
            {
                // 수납 대기 목록에서 선택
                var selectForm = new Form
                {
                    Text = "처방전 발급 - 환자 선택",
                    Size = new Size(350, 300),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    BackColor = Color.White
                };

                var lbl = new Label
                {
                    Text = "처방전을 발급할 환자를 선택하세요.",
                    Font = new Font("맑은 고딕", 10, FontStyle.Bold),
                    Location = new Point(15, 15),
                    AutoSize = true
                };
                selectForm.Controls.Add(lbl);

                var listBox = new ListBox
                {
                    Location = new Point(15, 45),
                    Size = new Size(300, 150),
                    Font = new Font("맑은 고딕", 10)
                };

                foreach (var p in payList)
                    listBox.Items.Add($"{p.Number}번 - {p.Name} ({p.Dept})");

                selectForm.Controls.Add(listBox);

                var btnOk = new Button
                {
                    Text = "선택",
                    Location = new Point(130, 210),
                    Size = new Size(80, 30),
                    Font = new Font("맑은 고딕", 9, FontStyle.Bold),
                    DialogResult = DialogResult.OK
                };
                selectForm.Controls.Add(btnOk);
                selectForm.AcceptButton = btnOk;

                if (listBox.Items.Count > 0) listBox.SelectedIndex = 0;

                if (selectForm.ShowDialog(this) == DialogResult.OK && listBox.SelectedIndex >= 0)
                {
                    target = payList[listBox.SelectedIndex];
                }
                selectForm.Dispose();
            }
            else
            {
                KioskMessageBox.Show(this, "처방전을 발급할 환자가 없습니다.\n먼저 [호출] 후 [진료 완료]를 진행하세요.");
                return;
            }

            if (target == null) return;

            string phone = "-";
            if (patientDb.TryGetValue((target.Name, target.Birth), out string foundPhone))
                phone = foundPhone;

            var selectedSymptoms = target.Symptoms
                .Split(',')
                .Select(s => s.Trim());

            List<string> medicines = new List<string>();

            foreach (var symptom in selectedSymptoms)
            {
                if (symptomPrescriptionMap.ContainsKey(symptom))
                    medicines.AddRange(symptomPrescriptionMap[symptom]);
            }

            string medicineText =
                medicines.Count > 0 ? string.Join(", ", medicines.Distinct()) : "일반 진통제";

            var frm = new picTemplate();
            frm.Fill(target, phone, medicineText);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            btnGoRegister.ForeColor = Color.Black;
            btnGoPay.ForeColor = Color.Black;

            btnGoRegister.Font = new Font("맑은 고딕", 20, FontStyle.Bold);
            btnGoPay.Font = new Font("맑은 고딕", 20, FontStyle.Bold);

            ApplyRoundButton(btnGoRegister, 40);
            ApplyRoundButton(btnGoPay, 40);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // 입력 초기화
            txtName.Text = "";
            txtBirth.Text = "";
            txtPhone.Text = "";
            txtAddr.Text = "";

            txtExName.Text = "";
            txtExBirth.Text = "";

            //접수 상태 초기화 (이게 중요)
            isPatientVerified = false;
            verifiedName = "";
            verifiedBirth = "";

            for (int i = 0; i < clbSymptoms.Items.Count; i++)
                clbSymptoms.SetItemChecked(i, false);

            rdoAgreeYes.Checked = false;
            rdoAgreeNo.Checked = false;

            UpdatePayCount();
            TabPage.SelectedTab = tabHome;
        }

        private void lblWaitPay_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvPay.CurrentRow == null || dgvPay.CurrentRow.Index < 0)
            {
                KioskMessageBox.Show(this, "결제할 환자를 선택하세요.", "안내", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = dgvPay.CurrentRow.DataBoundItem as WaitItem;
            if (item == null) return;

            // 진료비 계산
            int fee = deptFee.ContainsKey(item.Dept) ? deptFee[item.Dept] : 15000;

            // 결제 폼 열기
            var payForm = new FormPayment(item.Name, item.Dept, fee);
            var result = payForm.ShowDialog(this);

            if (result == DialogResult.OK && payForm.PaymentCompleted)
            {
                // 현금이 아닐 때만 영수증 출력 여부 확인
                if (payForm.SelectedMethod != "현금")
                {
                    var receiptResult = KioskMessageBox.Show(
                        this,
                        "결제가 완료되었습니다.\n영수증을 출력하시겠습니까?",
                        "영수증 출력",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (receiptResult == DialogResult.Yes)
                    {
                        var receiptForm = new FormReceipt(item.Name, item.Dept, fee, payForm.SelectedMethod);
                        receiptForm.ShowDialog(this);
                    }
                }

                // 수납 목록에서 제거
                payList.Remove(item);
                paySource.ResetBindings(false);
                UpdateHomePayCount();
                UpdatePayCount();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // 접수 입력 초기화
            txtName.Text = "";
            txtBirth.Text = "";
            txtPhone.Text = "";
            txtAddr.Text = "";

            txtExName.Text = "";
            txtExBirth.Text = "";

            // 증상 체크 해제
            for (int i = 0; i < clbSymptoms.Items.Count; i++)
                clbSymptoms.SetItemChecked(i, false);

            // 개인정보 동의 초기화
            rdoAgreeYes.Checked = false;
            rdoAgreeNo.Checked = false;

            // 화면 홈으로 이동
            TabPage.SelectedTab = tabHome;

            btnReset.Location = new Point(this.ClientSize.Width - 55, 10);
        }

        private void btnHomeRegister_Click(object sender, EventArgs e)
        {
            // 입력 초기화
            txtName.Text = "";
            txtBirth.Text = "";
            txtPhone.Text = "";
            txtAddr.Text = "";

            txtExName.Text = "";
            txtExBirth.Text = "";

            for (int i = 0; i < clbSymptoms.Items.Count; i++)
                clbSymptoms.SetItemChecked(i, false);

            rdoAgreeYes.Checked = false;
            rdoAgreeNo.Checked = false;

            // 홈 이동
            TabPage.SelectedTab = tabHome;
        }

        private void timerBlink_Tick(object sender, EventArgs e)
        {
            if (blinkOn)
                lbHomeBig.ForeColor = Color.Black;
            else
                lbHomeBig.ForeColor = Color.Red;

            blinkOn = !blinkOn;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            TabPage.SelectedTab = tabRegister;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            TabPage.SelectedTab = tabPay;
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBirth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAddr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '가' && e.KeyChar <= '힣')
        || char.IsDigit(e.KeyChar)
        || char.IsWhiteSpace(e.KeyChar)
        || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void tabWaitCall_Click(object sender, EventArgs e)
        {

        }

        private void tabMain_Resize(object sender, EventArgs e)
        {
            AdjustWaitTabLayout();
            AdjustPayTabLayout();
        }

        private void timerAd_Tick(object sender, EventArgs e)
        {
            lblAdWait.Text = waitAds[noticeIndex];
            lblAdPay.Text = payAds[noticeIndex];

            noticeIndex++;

            if (noticeIndex >= waitAds.Length)
                noticeIndex = 0;
        }

        private string registerInfoText = "      건강검진 예약 문의 : 1588-0000      ";
        private void timerRegisterAd_Tick(object sender, EventArgs e)
        {
            registerAdText = registerAdText.Substring(1) + registerAdText[0];
            registerInfoText = registerInfoText.Substring(1) + registerInfoText[0];

            lblAdRegister.Text = registerAdText;
            lbregister.Text = registerInfoText;
        }
    }
}