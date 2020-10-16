namespace JLane_Assignment4
{
    partial class ImageDocumentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBoxImageDocPicBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImageDocPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxImageDocPicBox
            // 
            this.picBoxImageDocPicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxImageDocPicBox.Location = new System.Drawing.Point(0, 0);
            this.picBoxImageDocPicBox.Name = "picBoxImageDocPicBox";
            this.picBoxImageDocPicBox.Size = new System.Drawing.Size(694, 359);
            this.picBoxImageDocPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxImageDocPicBox.TabIndex = 0;
            this.picBoxImageDocPicBox.TabStop = false;
            // 
            // ImageDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 359);
            this.Controls.Add(this.picBoxImageDocPicBox);
            this.Name = "ImageDocumentForm";
            this.Text = "Image Document Form";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImageDocPicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxImageDocPicBox;
    }
}