    private void btnSmallJob_Click(object sender, EventArgs e)
    {
        Task myTask = new Task(SmallTaskCode);
        myTask.Start();  // NOTE: I'm NOT doing a wait() on this task; don't want to hold up the GUI thread.
    }
    private void SmallTaskCode()
    {
        System.Threading.Thread.Sleep(1000);
        txtResults.BeginInvoke(new Action(() => txtResults.Text += DateTime.Now.ToString() + " Small Job" + Environment.NewLine));
        System.Threading.Thread.Sleep(1000);
    }
    Task singleInstanceOfLargeJob;
    private void btnLargeJob_Click(object sender, EventArgs e)
    {
        if (this.singleInstanceOfLargeJob == null || this.singleInstanceOfLargeJob.Status != TaskStatus.Running)
        {
            singleInstanceOfLargeJob = new Task(LargeTaskCode);
            singleInstanceOfLargeJob.Start();  // NOTE: I'm NOT doing a wait() on this task; don't want to hold up the GUI thread.
            return;
        }
        MessageBox.Show("Sorry, you can only have one instance of the large job running at once!");
        // this job should only have one instance running at a time!
    }
    private void LargeTaskCode()
    {
        System.Threading.Thread.Sleep(1000);
        txtResults.BeginInvoke(new Action(() => txtResults.Text += DateTime.Now.ToString() + " Big Job A" + Environment.NewLine));
        System.Threading.Thread.Sleep(1000);
        txtResults.BeginInvoke(new Action(() => txtResults.Text += DateTime.Now.ToString() + " Big Job B" + Environment.NewLine));
        System.Threading.Thread.Sleep(1000);
        txtResults.BeginInvoke(new Action(() => txtResults.Text += DateTime.Now.ToString() + " Big Job C" + Environment.NewLine));
        System.Threading.Thread.Sleep(1000);
    }
