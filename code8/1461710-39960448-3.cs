    var data = contextObj.ServiceMonitorMappings
                .Where(r => r.ServiceId == 33)
                .AsEnumerable()  //AsEnumerable after Where to apply filter on the DB query
                .GroupBy(x => 1) //data already filtered, only one group as a result
                .Select(x => new
                {
                    ServiceName = x.First().Service.Name,
                    Ping = x.First().Service.PingUrl,
                    Desc = x.First().Service.Description,
                    LogName = x.First().ServiceLoggingName.LoggingName,
                    BaseUrl = x.Select(y => y.ServiceBaseUrl.ServiceBaseUrl1).ToList(), //ToList is optional
                    EnvName = x.Select(y => y.ServiceEnvironment.Name).ToList() //ToList is optional
                });
