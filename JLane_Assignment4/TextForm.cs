using System.IO;
using System.Windows.Forms;

namespace JLane_Assignment4
{
    public partial class TextForm : Form
    {
        public TextForm()
        {
            InitializeComponent();
        }

        public string TextFormText
        {
            get { return txtTextFromTextBox.Text; }
        }

        public string FetchTextBoxValue()
        {
            return txtTextFromTextBox.Text;
        }

        public void GrabTextFromFile(string filePathArgument)
        {
            if (!string.IsNullOrWhiteSpace(filePathArgument))
            {
                txtTextFromTextBox.Text = File.ReadAllText(filePathArgument);
                return;
            }

            Close();
        }

    }
}
