    public partial class Form1 : Form
    {
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // TODO: query your database
            // for easier reading I assume that your query-result has only one column
            var queryResult = new List<object>();
            backgroundWorker1.ReportProgress(10);
            var table = new DataTable();
            // TODO: create matching columns for your query-result in the datatable
            // https://msdn.microsoft.com/de-de/library/system.data.datatable.newrow(v=vs.110).aspx
            for (var i = 0; i < queryResult.Count; i++)
            {
                var progress = 10 + (int)((float)i / queryResult.Count) * 90;
                backgroundWorker1.ReportProgress(progress);
                // TODO: add the row data to the table
                // same link as before: https://msdn.microsoft.com/de-de/library/system.data.datatable.newrow(v=vs.110).aspx
            }
            e.Result = table;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataTable table = (DataTable)e.Result;
            // TODO: Check for errors
            // TODO: Assign the table to your grid
            // TODO: unlock your ui, hide progress dialog
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // TODO: update your progress dialog/progressbar, f.e.
            progressBar1.Value = e.ProgressPercentage;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;
            backgroundWorker1.RunWorkerAsync();
            // TODO: lock your ui, show progress dialog or progressbar...
        }
    }
