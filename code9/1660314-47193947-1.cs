            public class Parameters
            {
                public string message = "";
            }
            private void startAsync_Click(object sender, EventArgs e)
            {
                if (backgroundWorker1.IsBusy != true)
                {
                    // Start the asynchronous operation.
                    Parameters parameters = new Parameters() { message = "The quick brown fox jumped over the lazy dog" };
                    
                    backgroundWorker1.RunWorkerAsync(parameters);
                }
            }
            private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
            {
                Parameters parameters = e.Argument as Parameters;
            }
