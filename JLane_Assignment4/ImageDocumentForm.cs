using System.Windows.Forms;

namespace JLane_Assignment4
{
    public partial class ImageDocumentForm : Form
    {
        public ImageDocumentForm()
        {
            InitializeComponent();
        }

        public void GrabImageFromFile(string filePathArgument)
        {
            if (!string.IsNullOrWhiteSpace(filePathArgument))
            {
                picBoxImageDocPicBox.ImageLocation = filePathArgument;
            }
            else
            {
                Close();
            }
            
        }


    }
}
