           // Use ParallelOptions instance to store the CancellationToken
            ParallelOptions po = new ParallelOptions();
            po.CancellationToken = cts.Token;
            po.MaxDegreeOfParallelism = Environment.ProcessorCount;
            try
            {
                Parallel.ForEach<ListViewItem>(filesListView.Items.Cast<ListViewItem>(), po, item => {
                    if (CallToStop == true)
                    {  
                        //Code here to stop the loop!
                        cts.Cancel();
                    }        
                    internalProcessStart(item);
                });
            }
            finally
            {
                cts.Dispose();
            }
