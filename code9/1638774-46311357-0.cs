    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.WebApi;
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using Web.Models;
    [ assembly:WebActivatorEx.PreApplicationStartMethod(typeof(Web.App_Start.NinjectWebCommon), "Start")]
    [ assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Web.App_Start.NinjectWebCommon), "Stop")]
    namespace Web.App_Start {
    public static class NinjectWebCommon {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop() {
            bootstrapper.ShutDown();
        }
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel() {
            var kernel = new StandardKernel();
            try {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver =
                    new NinjectDependencyResolver(kernel);
                return kernel;
            } catch {
                kernel.Dispose();
                throw;
            }
        }
        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel) {
            System.Web.Mvc.DependencyResolver.SetResolver(new
                MvcNinjectDependencyResolver(kernel));
        }
    }
    public class MvcNinjectDependencyResolver : IDependencyResolver {
        private IKernel kernel;
        public MvcNinjectDependencyResolver(IKernel kernelParam) {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType) {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType) {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings() {
            kernel.Bind<IDiscountHelper>()
                .To<DiscountHelper>()
                    .WithPropertyValue(nameof(DiscountHelper.DiscountSize), 15.0M);
            kernel.Bind<ILinqValueCalculator>().To<LinqValueCalculator>();
            kernel.Bind<IShoppingCart>().To<ShoppingCart>();
        }
    }
