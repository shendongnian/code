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
            var check = await PingAsync(listIps);
            communication.Result = check.Any(p => p.Status.Equals(IPStatus.Success)) ? "OK" : "NOK";
         }
     }
