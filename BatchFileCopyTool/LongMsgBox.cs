using MetroFramework.Forms;
using System;

namespace BatchFileCopyTool
{
    public partial class LongMsgBox : MetroForm
    {
        public LongMsgBox()
        {
            InitializeComponent();
        }

        private void LongMsgBox_Load(object sender, EventArgs e)
        {
            LongMsgTextBox.Text = PassData.longMsg;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            PassData.isOk = true;
            this.Close();
        }

        private void CanlceButton_Click(object sender, EventArgs e)
        {
            PassData.isOk = false;
            this.Close();
        }

        private void LongMsgBox_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
        }
    }
}
