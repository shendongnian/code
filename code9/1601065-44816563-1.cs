     private void textBoxEmpNo_TextChanged(object sender, EventArgs e)
            {
                bool fileFound = false;
                const string baseFolder = @"\\\\egmnas01\\hr\\photo";
    
                string[] matchedFiles = Directory.GetFiles(baseFolder, "*" + textBoxEmpNo.Text + "*.jpeg", SearchOption.AllDirectories);
    
                if (matchedFiles.Length == 0)
                {
                    buttonSearch.Enabled = false;
                }
                else
                {
                    buttonSearch.Enabled = true;
                    fileFound = true;
                }
            }
