     // this array must be declared as global field
     public string[] files;
     private void Button_OpenFile_Click(object sender, EventArgs e)
     {
         FolderBrowserDialog OpenFBD = new FolderBrowserDialog();
         if (OpenFBD.ShowDialog() == DialogResult.OK)
         {
             LBX_Files.Items.Clear();
    
             files = System.IO.Directory.GetFiles(OpenFBD.SelectedPath);
             foreach (string file in files)
             {
                 LBX_Files.Items.Add(System.IO.Path.GetFileName(file));
             }
         }
     }
    
     private void LBX_Files_SelectedIndexChanged(object sender, EventArgs e)
     {
         
             L_ShowContents.Text = File.ReadAllText( files.FirstOrDefault(x => x.Contains(LBX_Files.SelectedItem.ToString())));
     }
