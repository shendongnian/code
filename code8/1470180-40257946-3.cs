    public override SockResponse Process(Socket socket, Client client)
    {
        return Task.Factory.StartNew(() =>
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
        }).Result;
    }
