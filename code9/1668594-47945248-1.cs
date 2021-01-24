    using System;
    using System.Linq;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.EntityFrameworkCore;
    using ServiceBrokerListener.Domain;
    using PROJECT.Models.Queries;
    namespace PROJECT.Models.Tracking
    {
        public static class Tracker
        {
            public struct Props { public string dbConn, dbName, dbTable; }
            private static SqlDependencyEx dependency;
            public static void Start(Tracker.Props props, IServiceProvider sp)
            {
                if (dependency == null)
                {
                    dependency = new SqlDependencyEx(props.dbConn, props.dbName, props.dbTable, identity: 1);
                    RegisterEvents(dependency, sp);
                    dependency.Start();
                }
            }
            private static void RegisterEvents(SqlDependencyEx dp, IServiceProvider sp)
            {
                dp.TableChanged += (obj, e) =>
                {
                    if (MyHub.ConnectedIds.Count > 0)
                    {
                        //db and hub context from service provider
                        var context = sp.GetService(typeof(DATABASEContext)) as DATABASEContext;
                        var hubcontext = sp.GetService(typeof(IHubContext<MyHub>)) as IHubContext<MyHub>;
                        //call hub to launch event, db context has extension for count query
                        hubcontext.Clients.All.InvokeAsync("countA", context.GetCountA())
                        hubcontext.Clients.All.InvokeAsync("countB", context.GetCountB())
                    }
                };
            }
        }
    }
