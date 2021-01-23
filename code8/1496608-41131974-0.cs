    public static async Task<List<Communication>> Foo(List<Dispositive> listToPing)
    {
        var listResult = new List<Communication>();
        foreach (var item in listToPing)
        {
            var listIps = item.listIps;
            var communication = new Communication
            {
                IdDispositive = item.Id
            };
            try
            {
                var ping = new Ping();
                communication.Result = "NOK";
                for (var i = 0; i < listIps.Count(); i++)
                {
                    var oPing = await ping.SendPingAsync(listIps.ElementAt(i).IpAddress, 10000);
                    if (oPing != null)
                    {
                        if (oPing.Status.Equals(IPStatus.Success)
                        {
                            communication.Result = "OK";
                            break;
                        }
                    }
                }
            }
            catch
            {
                communication.Result = "NOK";
            }
            finally
            {
                listResult.Add(communication);
            }
        }
    
        return listResult;
    }
