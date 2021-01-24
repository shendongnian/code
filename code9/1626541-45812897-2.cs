    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.ApplicationInsights;
    using Microsoft.ApplicationInsights.Extensibility;
    
    namespace WebJob1
    {
        public class Functions
        {
            public static void TimerJob([TimerTrigger("00:01:00")] TimerInfo timerInfo, TextWriter log)
            {
                new TelemetryClient().TrackEvent("testing "+ DateTime.UtcNow.ToShortDateString(), new Dictionary<string, string> { { "appInsightsInstrumentationKey", TelemetryConfiguration.Active.InstrumentationKey } });
    
                log.WriteLine("Process Something called at : " + DateTime.Now.ToShortDateString());
            }
        }
    }
