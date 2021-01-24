     private void textBoxEmpNo_TextChanged(object sender, EventArgs e)
            {
                bool fileFound = false;
                const string baseFolder = @"C:\Users\matesush\Pictures";
    
                if (Directory.EnumerateFiles(baseFolder, "*" + textBoxEmpNo.Text + "*.jpeg", SearchOption.AllDirectories).Any())
                {
                    buttonSearch.Enabled = true;
                    fileFound = true;
                }
                else
                {
                    buttonSearch.Enabled = false;
                }
            }
