    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Timers;
    using System.Xml.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Threading;
    using System.ServiceProcess;
    using System.Configuration.Install;
    using System.Reflection;
    
    namespace Test
    {
    
        class Program : ServiceBase
        {
    
            static void Main(string[] args)
            {  
                	if (System.Environment.UserInteractive)
                    {
                        log.Debug("App");
                    }
                    else
                    {
                        ServiceBase.Run(new ServiceBase[] { new Program() });
                    }
            }
    
    
            protected override void OnStart(string[] args)
            {
                log.Info("Starting service");
            }
    
            protected override void OnStop()
            {
                log.Info("Stopping service");
            }
        }
    
    
    }
