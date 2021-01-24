    private void btnColumnIndexApply_Click(object sender, RoutedEventArgs e) 
    {
        MainWindow originalForm = Application.Current.MainWindow; //here
        int correctColumnNumber = int.Parse(txtColumnIndexCorrection.Text);
        column.Index = correctColumnNumber - 1;
        originalForm.UpdateSingleColumnIndex(column);
        originalForm.TriggerReadDataFile(this.filePath, this.fileExt, this.tableType);
        this.Close();
    }
