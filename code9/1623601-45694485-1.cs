    private void btnSave_Click(object sender, EventArgs e)
    {
        SaveFileDialog save = new SaveFileDialog();
        save.InitialDirectory = @"C:\";
        save.RestoreDirectory = true;
        save.Title = "Select save location file name";
        save.DefaultExt = "xml"; // surely should be xlsx??
        //Showing the dialog
        if(save.ShowDialog() == DialogResult.Ok)
        {
            ToExcel(save.FileName);
        }
    }
    private void ToExcel(string saveFile){...}
