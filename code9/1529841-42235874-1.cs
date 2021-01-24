    private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
    {
        while(true)
        {
            try
            {
                string name = saveFileDialog1.FileName; // Get file name.        
                File.WriteAllText(name, CsvExport);     // Write to the file name selected.
                return;
            }
            catch (Exception ex)
            {
                //file is locked, how to get back to the open save file dialog ???
                // maybe display an error message here so that the user knows why they're about to see the dialog again.
            }
            ShowSaveFileDialog();
        }
    }
