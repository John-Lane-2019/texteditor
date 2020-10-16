using System;
using System.IO;
using System.Windows.Forms;

namespace JLane_Assignment4
{
    public partial class MainForm : Form
    {
        bool saved = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void ToolStripMenuItemTextDocument_Click(object sender, EventArgs e)
        {
            TextForm textForm = new TextForm
            {
                MdiParent = this
            };
            textForm.Show();
        }

        private void ToolStripOpentTextDoc_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                AddExtension = true,
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "TXT(*.txt)|*.txt",
                Multiselect = false
            };

            string filePathArgument = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePathArgument += ofd.FileName;
            }

            TextForm textForm = new TextForm
            {
                MdiParent = this
            };
            textForm.Show();
            textForm.GrabTextFromFile(filePathArgument);
        }

        private void ImageDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                AddExtension = true,
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "JPG(*.jpg)|*.jpg|PNG(*.png)|*.png|BMP(*.bmp)|*.bmp",
                Multiselect = false
            };

            string filePathArgument = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                filePathArgument += filePath;
            }

            ImageDocumentForm imageDocumentForm = new ImageDocumentForm
            {
                MdiParent = this
            };
            imageDocumentForm.Show();
            imageDocumentForm.GrabImageFromFile(filePathArgument);
        }

        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            //toolStripSaveAs.Enabled = ActiveMdiChild is TextForm;

            if (ActiveMdiChild is TextForm)
            {
                toolStripSaveAs.Enabled = true;
            }

            else
            {
                toolStripSaveAs.Enabled = false;
            }

            if (ActiveMdiChild is TextForm)
            {
                statusLabel.Text = "Text form active";
            }

            else if (ActiveMdiChild is ImageDocumentForm)
            {
                statusLabel.Text = "Image form active";
            }

            else
            {
                statusLabel.Text = "No form is active";
            }
        }

        private void ClosingForm(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                ExitAndSave(sender, e);
            }
        }

        private void ExitAndSave(object sender, EventArgs e)
        {
            foreach (Form form in MdiChildren)
            {
                if (form is TextForm tf)//if the form is a text form it is cast into a TextForm and stored in variable 'tf', without 'tf' it is only a type check
                {
                    tf.BringToFront();
                    DialogResult dr = MessageBox.Show("Do you want to save your document?", "Save document?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        var textBoxValue = tf.FetchTextBoxValue();
                        string filePath = $"composition{DateTime.Now.Ticks.ToString()}.txt";
                        File.WriteAllText(filePath, textBoxValue);
                    }
                }

                else if (form is ImageDocumentForm)
                {
                    MessageBox.Show("Please note that only text documents can be saved.", "Advisory:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            saved = true;
            Close();
        }

        private void CascadeWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutMe aboutMe = new AboutMe();
            aboutMe.ShowDialog();
            aboutMe.isModal = true;
        }

        private void NewToolStripButton_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemTextDocument_Click(sender, e);
        }

        private void OpenToolStripButton_Click(object sender, EventArgs e)
        {
            ToolStripOpentTextDoc_Click(sender, e);
        }

        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is TextForm)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.AddExtension = true;
                sfd.CheckPathExists = true;
                sfd.Filter = "TEXT(*.txt)|*.txt";
                sfd.InitialDirectory = Environment.CurrentDirectory;
                sfd.Title = "Save Text Document";
                sfd.ValidateNames = true;
                sfd.OverwritePrompt = true;

                TextForm activeTextForm = (TextForm)ActiveMdiChild;
                string saveString = activeTextForm.TextFormText;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (Stream stream = File.Open(sfd.FileName, FileMode.Create))
                    using (StreamWriter sw = new StreamWriter(stream))
                    {
                        sw.WriteLine(saveString);
                    }

                }

            }
            if (ActiveMdiChild is ImageDocumentForm)
            {
                MessageBox.Show("Only text documents may be saved. Please select a text document.", "Advisory:",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void toolStripSaveAs_Click(object sender, EventArgs e)
        {
            SaveToolStripButton_Click(sender, e);
        }

        private void HelpToolStripButton_Click(object sender, EventArgs e)
        {
            AboutToolStripMenuItem_Click(sender, e);
        }
    }
}






