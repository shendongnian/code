    using System;
    using DiTestingApp.Models;
    using Microsoft.Practices.Unity;
    using Quartz;
    using Testing.Scheduler;
    
    namespace DiTestingApp
    {
        /// <summary>
        /// Specifies the Unity configuration for the main container.
        /// </summary>
        public static class UnityConfig
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="container"></param>
            /// <param name="disposableLifetimeManager"></param>
            /// <returns></returns>
            public static IUnityContainer Configure(this IUnityContainer container, Func<LifetimeManager> disposableLifetimeManager )
            {
                
                container.RegisterType<IJob, HelloWorldJob>();
                container.RegisterType<IHelloService, HelloService>(disposableLifetimeManager());
                return container;
            }
        }
    }
