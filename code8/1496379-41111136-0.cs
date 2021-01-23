    private async Task<bool> TryThis()
        {
            Trace.TraceInformation("Starting TryThis");
            await Task.Run(() =>
            {
                Trace.TraceInformation("In TryThis task");
                for (int i = 0; i < 100; i++)
                {
                    // This runs successfully - the loop runs to completion
                    Trace.TraceInformation("For loop " + i);
                    System.Threading.Thread.Sleep(10);
                }
            });
            // This never happens due to the deadlock
            Trace.TraceInformation("About to return");
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool result = TryThis().Result;
            // Never actually gets here
            Trace.TraceInformation("Done with result");
        }
