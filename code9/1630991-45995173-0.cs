    class MyForm : Form
    {
        public MyForm()
        {
             InitializeComponents();
             this.myReadItems = new BindingList<MyReadData>();
             this.MyBindingSource.DataSource = this.myReadItems;
             // if not already done in InitializeComponents
             this.MyDataGridView.DataSource = this.MyBindingSource;
        }
        private readonly BindingList<MyReadData> myReadItems;
        // whenever needed, start the BackGroundWorker.
 
        private void OnButtonReadFile_Click(object send, EventArgs e)
        {
             // create and start the backgroundworker
             BackGroundWorkdr worker = ...
             MyBackGroundWorkerParams params = ...
             worker.RunWorkerAsync(params);
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // I am certain the sender is my BackGroundWorker:
            BackgroundWorker worker = (BackGroundWorker)sender;
            MyBackGroundWorkerParams params = (MyBackGroundWorkerParams)e.Argument;
            // do some work using the params
            while (readData != null)
            {
                // some data read.
                // dont't add the data to the list, just report the data that must been added to the list:
                // someCalculations...
                int percentProgress = ...
                MyReadData dataToAddToGrid = ...
                worker.ReportProgress(percentProgress, dataToAddToGrid);
             }
             private void bw_progressChanged(object sender, ProgressChangedEventArgs e)
             {
                 // no need to call invoke, this is already the context of your forms thread
                 Debug.Assert(!This.InvokeReguired);
                 MyReadData dataToAdddToGrid = (MyReadData)e.UserState;
                 this.myReadItems.Add(dataToAddToGrid);
             }
    }
 
