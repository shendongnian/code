    private void OnFormClosing(object sender, CancelEventArgs e)
    {
        bool asyncProcessRunning = this.MyTask != null && !this.MyTaks.IsCompleted;
        if (processRunning)
        {
            MessageBox.Show(this, "Can't close. Task still running", this.Text, 
                MessageBoxButton.OK,
                MessageBoxIcon.Warning);
            e.Cancel = true;
        }
     }
