    var data = contextObj.ServiceMonitorMappings
                .Where(r => r.ServiceId == 33)
                .Select(x => new
                {
                    Key = new {ServiceName = x.Service.Name,
                               Ping = x.Service.PingUrl,
                               Desc = x.Service.Description,
                               LogName = x.ServiceLoggingName.LoggingName};
                    BaseUrl = x.ServiceBaseUrl.ServiceBaseUrl1,
                    EnvName = x.ServiceEnvironment.Name
                })
                .GroupBy(x => x.Key)
                .Select(g => new
                {
                  ServiceName = g.Key.ServiceName,
                  Ping = g.Key.Ping,
                  Desc = g.Key.Desc,
                  LogName = g.Key.LogName,
                  BaseUrls = g.Select(x => x.BaseUrl).ToList(),
                  EnvNames = g.Select(x => x.EnvName ).ToList();
                })
