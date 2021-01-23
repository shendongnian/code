    // this code is the DoWork event of the BackgroundWorker
    private void bgw_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker bkw = sender as BackgroundWorker;
        .....
        using (SqlConnection conn = new SqlConnection(_myHost))
        {
            conn.Open();
            int counter  = 1;
            foreach (string item in myList)
            {
                .....
    
                WorkerItem item = new WorkerItem() { Counter = counter, Item = item};
                bkw.ReportProgress(counter, item);
                counter++;
            }
        }
    }
    public class WorkerItem
    {
        public int Counter {get;set;}
        public string Item {get;set;}
        ... add other properties if you like .....
    }
