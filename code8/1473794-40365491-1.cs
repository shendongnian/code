    private void backupDocumentsButton_Click(object sender, EventArgs e)
    {
        clickedButton = ((Button)sender).Text.ToString();
        selectedDrive = backupDriveCombo.SelectedItem.ToString();
        //bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork); without this line
        bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);
        bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
        bgWorker.WorkerReportsProgress = true;
        bgWorker.RunWorkerAsync();
    }
