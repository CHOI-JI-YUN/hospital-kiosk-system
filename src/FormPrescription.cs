using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk
{
    public partial class picTemplate : Form
    {
        public picTemplate()
        {
            InitializeComponent();
        }

        public void Fill(Kiosk.WaitItem item, string phone, string medicineText)
        {
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblName.Text = string.IsNullOrWhiteSpace(item.Name) ? "-" : item.Name;
            lblBirth.Text = string.IsNullOrWhiteSpace(item.Birth) ? "-" : item.Birth;

            lblMedicine.Text = string.IsNullOrWhiteSpace(medicineText) ? "-" : medicineText;
        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void lblBirth_Click(object sender, EventArgs e)
        {

        }

        private void lblPhone_Click(object sender, EventArgs e)
        {

        }

        private void picTemplate_Load(object sender, EventArgs e)
        {

        }
    }
}
