    using System;
    using Microsoft.Practices.Unity;
    using WeeklyReport.Repository;
    using System.Web.Mvc;
    using Unity.Mvc3;
    namespace WeeklyReport
    {
        public class UnityConfig
        {
            public static void RegisterContainer()
            {
                var container = new UnityContainer();
                //ensure the repository is disposed after each request by using the lifetime manager
                container.RegisterType<IDataRepository, DataRepository>(new HierarchicalLifetimeManager());
                DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            }
        }
    }
