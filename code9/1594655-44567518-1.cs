     private string filePath = string.Empty;
        private void saveFile()
        {
            if (File.Exists(filePath))
            {
                byte[] buffer = Encoding.ASCII.GetBytes(richTextBox1.Text);
                MemoryStream ms = new MemoryStream(buffer);
                //write to file
                FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                ms.WriteTo(file);
                file.Close();
                ms.Close();
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Rich Text File | *.rtf";
                sfd.OverwritePrompt = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SaveFile(sfd.FileName);
                    filePath = sfd.FileName;
    
                }
            }
        }
