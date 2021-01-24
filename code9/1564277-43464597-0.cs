        private void saveImageAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSaveDialog();
        }
        private void ShowSaveDialog()
        {
            PictureBox pb = pictureBox1;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filepath = System.IO.Path.GetExtension(sfd.FileName);
                if (pb != null && sfd.FileName != null)
                {
                    Image im = pb.Image;
                    SaveImage(im, sfd.FileName);
                }
            }
            
        }
        private static void SaveImage(Image im, string destPath)
        {
            im.Save(destPath, System.Drawing.Imaging.ImageFormat.Png);
        }
