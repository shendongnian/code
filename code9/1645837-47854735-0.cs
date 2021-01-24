      if (string.IsNullOrEmpty(metroGrid2.CurrentRow.Cells["FileName"].Value as string))
                   {
                       MessageBox.Show("no");
                   }
                   else
                   {
                       FolderBrowserDialog fbd = new FolderBrowserDialog();
                       if (fbd.ShowDialog() == DialogResult.OK)
                       {
                           folder = fbd.SelectedPath;
                       
               }
           }
