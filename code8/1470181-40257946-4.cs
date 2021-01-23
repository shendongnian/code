    public async Task<SockResponse> ProcessAsync(Socket socket, Client client)
    {
        var task = Task.Factory.StartNew(() =>
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
                return rsp;
            }
            return rsp;
        });
        return await task;
    }
