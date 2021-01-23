    private void backupDocumentsButton_Click(object sender, EventArgs e)
    {
        clickedButton = ((Button)sender).Text.ToString();
        selectedDrive = backupDriveCombo.SelectedItem.ToString();
        // without these lines
        // bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork); 
        // bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);
        // bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
        bgWorker.WorkerReportsProgress = true;
        bgWorker.RunWorkerAsync();
    }
