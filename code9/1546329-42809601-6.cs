    System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker();
    private void Form1_Load(object sender, EventArgs e)
    {
        worker.DoWork += Worker_DoWork;
    }
