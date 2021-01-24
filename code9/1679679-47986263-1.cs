    var proxies = proxyList.Select(x => new Proxy(x)).ToList();
 
    Parallel.ForEach(webSites, new ParallelOptions { MaxDegreeOfParallelism = 4 }, site =>
       {
          Parallel.ForEach(proxies.OrderByDescending(x => x.LastSuccess), new ParallelOptions { MaxDegreeOfParallelism = 4 }, proxy =>
          {               
             if(!CheckProxy(proxy))
             {
                //check next proxy
                return;
             }
             // if we found a good proxy
             // update the lastSuccess so we check that first
             proxy.LastSuccess = DateTime.Now;
             // do something to the website 
          });
       });
    }
