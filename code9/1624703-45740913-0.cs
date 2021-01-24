    private void btnOne_Click(object sender, EventArgs e)
    {
        if (filepath == null)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = @"C:\";
            save.RestoreDirectory = true;
            save.Title = "Select save location file name";
            save.DefaultExt = "xlsx";
    
            if (save.ShowDialog() == DialogResult.OK) {
                filepath = save.FileName;
            }
        }
        if (filepath != null) 
        {
            try
            {
                var file = new FileInfo(filepath);
                using (var package = new ExcelPackage(file))
                {
                    package.Save();
                }
            }
            catch { Messagebox.Show("An error has occured"; }
        }
    }
