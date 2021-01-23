           // Use ParallelOptions instance to store the CancellationToken
            ParallelOptions po = new ParallelOptions();
            po.CancellationToken = cts.Token;
            po.MaxDegreeOfParallelism = Environment.ProcessorCount;
            try
            {
                Parallel.ForEach<ListViewItem>(filesListView.Items.Cast<ListViewItem>(), po, item => {
                    // po.CancellationToken.ThrowIfCancellationRequested(); //1
                    if (CallToStop == true)
                    {  
                        //Code here to stop the loop!
                        cts.Cancel();
                    }
                    if (po.CancellationToken.IsCancellationRequested == false)
                    {        
                        internalProcessStart(item);
                    }
                });
            }
            catch (OperationCanceledException e)
            {
                // handle
            }
            finally
            {
                cts.Dispose();
            }
