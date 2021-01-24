    Here is how you could do it:
    
    #r "Microsoft.Azure.WebJobs.Extensions.ApiHub"
    
    using System;
    using System.IO;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host.Bindings.Runtime;
    
    public static async Task Run(TimerInfo myTimer, TraceWriter log, Binder binder)
    {
        log.Info($"C# Timer trigger function executed at: {DateTime.Now}");    
    
        var fileName = "mypath/" + DateTime.Now.ToString("yyyy-MM-ddThh-mm-ss") + ".txt";
    
        var attributes = new Attribute[]
        {    
            new ApiHubFileAttribute("onedrive_ONEDRIVE", fileName, FileAccess.Write)
        };
    
    
        var writer = await binder.BindAsync<TextWriter>(attributes);
        var content = $"Generated at {DateTime.Now} by Azure Functions"; 
    
        writer.Write(content);
    }
    
    
    And the function.josn file:
    
        {
      "bindings": [
        {
          "name": "myTimer",
          "type": "timerTrigger",
          "direction": "in",
          "schedule": "10 * * * * *"
        },
        {
          "type": "apiHubFile",
          "name": "outputFile",
          "connection": "onedrive_ONEDRIVE",
          "direction": "out"
        }
      ],
      "disabled": false
    }
