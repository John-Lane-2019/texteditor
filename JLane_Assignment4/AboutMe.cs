using System;
using System.Windows.Forms;

namespace JLane_Assignment4
{
    public partial class AboutMe : Form
    {
        public AboutMe()
        {
            InitializeComponent();
        }

        public bool isModal = false;

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
