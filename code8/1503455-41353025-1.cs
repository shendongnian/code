    public string getIPfromHost(string host)
            {
                try
                {
                    Task<string> task = Task<string>.Factory.StartNew(() =>
                    {
                         var domain = Dns.GetHostAddresses(host)[0];
                         return domain.ToString();
                    });
                   
                bool success = task.Wait(1000);
                if (success)
                {
                    return task.Result;
                }
                else
                {
                    return "No IP";
                }
    
                }
                catch (Exception)
                {
    
                    return "No IP";
                }
                   
            }
