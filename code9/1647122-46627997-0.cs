    class fact {
    /*...*/
    var backgroundWorker = new System.ComponentModel.BackgroundWorker();
    backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
    backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
            backgroundWorker_RunWorkerCompleted);
    private void backgroundWorker_DoWork(object sender, 
            DoWorkEventArgs e)
        {   
            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This is will be available to the 
            // RunWorkerCompleted eventhandler.
            var result = calcFact((long)e.Argument);
            var outputBkw = string.Empty;
            for (int i = 0; i < len; i++) outputBkw += res[i].ToString() + " ";
            e.Result = outputBkw;
        }
        private void backgroundWorker_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled 
                // the operation.                
                resultLabel.Text = "Canceled"; // or any other method you are showing status...
            }
            else
            {
                // Finally, handle the case where the operation 
                // succeeded.
                resultLabel.Text = e.Result.ToString();
                //Here you can use the result with the numbers calculated.
                // At this point you can have an event in the calc class to signal that the work is finished.
            }            
        }
