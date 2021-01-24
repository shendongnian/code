    private void btnOne_Click(object sender, EventArgs e)
    {
        if (Filename == null)
        {
        SaveFileDialog save = new SaveFileDialog();
        save.InitialDirectory = @"C:\";
        save.RestoreDirectory = true;
        save.Title = "Select save location file name";
        save.DefaultExt = "xlsx";
    
        if (save.ShowDialog() == DialogResult.OK)
        {
            try
            {
                Filename = save.FileName;
                var file = new FileInfo(save.FileName);
                using (var package = new ExcelPackage(file))
                {
                    package.Save();
                }
            }
            catch { Messagebox.Show("An error has occured"; }
        }
        }
        else
        {
            var file = new FileInfo(Filename);
            using (var package = new ExcelPackage(file))
            {
                package.Save();
            }
        }
    }
