    using Android.Content;
    using MvvmCross.Core.ViewModels;
    using MvvmCross.Droid.Platform;
    using Xamarin.Forms.Labs.Services;
    
    namespace SomeProject.UI.Droid
    {
        public class Setup : MvxAndroidSetup
        {
    
            public Setup(Context applicationContext) : base(applicationContext)
            {
                var resolverContainer = new SimpleContainer();
                resolverContainer.Register<IViewMethodCallService>(t => new ViewMethodCallService());
                Resolver.SetResolver(resolverContainer.GetResolver());
            }
    
            protected override IMvxApplication CreateApp()
            {
                return new App();
            }
        }
    }
