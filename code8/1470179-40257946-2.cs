    public override SockResponse Process(Socket socket, Client client)
    {
        BackgroundWorker worker = new BackgroundWorker();
        worker.DoWork += new DoWorkEventHandler(
            delegate (object sender, DoWorkEventArgs e)
            {
                CallResponse rsp = new CallResponse();
                try
                {
                    using (Transact X = client.Session.NewTransaction())
                    {
                        foreach (CallData call in Payload)
                        {
                            DataCall dataCall = new DataCall();
                            SqlDataReader rdr = dataCall.Execute(X, call);
                            rsp.Result.Add(dataCall.BuildResult(rdr));
                            rdr.Close();
                        }
                        rsp.ErrMsg = "";
                        X.Commit();
                    }
                }
                catch (Exception err)
                {
                    rsp.ErrMsg = err.Message;
                    e.Result = rsp;
                }
                e.Result = rsp;
            });
        TaskCompletionSource<SockResponse> tcs = new TaskCompletionSource<SockResponse>();
        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
            delegate (object sender, RunWorkerCompletedEventArgs e)
            {
                // First, handle the case where an exception was thrown.
                if (e.Error != null)
                {
                    Log.Logger.Error(e.Error.Message);
                }
                else if (e.Cancelled)
                {
                    // Next, handle the case where the user canceled 
                    // the operation.
                    // Note that due to a race condition in 
                    // the DoWork event handler, the Cancelled
                    // flag may not have been set, even though
                    // CancelAsync was called.
                    Log.Logger.Info("CALL process was cancelled");
                }
                else
                {
                    //  Then, handle the result
                    tcs.SetResult(e.Result);
                }
            });
        worker.RunWorkerAsync();
        return tcs.Task.Result;
    }
