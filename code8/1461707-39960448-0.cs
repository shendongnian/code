    var data = contextObj.ServiceMonitorMappings
                .GroupBy(r => r.ServiceId)
    			.Where(r => r.Key == 33)
                .Select(x => new
                {
                    ServiceName = x.First().Service.Name,
                    Ping = x.First().Service.PingUrl,
                    Desc = x.First().Service.Description,
                    LogName = x.First().ServiceLoggingName.LoggingName,
                    BaseUrl = x.SelectMany(y => y.ServiceBaseUrl.ServiceBaseUrl1).ToList(), //ToList is optional
                    EnvName = x.SelectMany(y => y.ServiceEnvironment.Name).ToList() //ToList is optional
                });
