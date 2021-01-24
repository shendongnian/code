        IAsyncResult result = cmd2.BeginExecuteNonQuery();
        int count = 0;
        while (!result.IsCompleted)
        {
             count++;
             if (count % 500 == 0)
             {
                lblProcessing.Text = "Transactions " + i.ToString();
                lblProcessing.Refresh();
             }
             // Wait for 1/10 second, so the counter
             // does not consume all available resources 
             // on the main thread.
             System.Threading.Thread.Sleep(100);
        }
