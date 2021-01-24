    #r "Newtonsoft.Json"
    
    using System;
    using System.Net;
    using Newtonsoft.Json;
    
    public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
    {
        log.Info($"Webhook was triggered!");
    
        if (req.Method == HttpMethod.Post)
        {
            log.Info($"POST method was used to invoke the function ({req.Method})");
        }
        else if (req.Method == HttpMethod.Get)
        {
            log.Info($"GET method was used to invoke the function ({req.Method})");
        }
        else
        {
            log.Info($"method was ({req.Method})");    
        }
    }
