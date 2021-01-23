    public class App : PrismApplication
    {
        protected override void RegisterTypes()
        {
            Container.Register<IMySettings,MySettings>( new ContainerControlledLifetimeManager() );
        }
    }
    public class MyPageViewModel
    {
        IMySettings _mySettings { get; }
        public MyPageViewModel( INavigationService navigationService, IMySettings mySettings )
        {
            _mySettings = mySettings;
            // Update this somewhere in the code before navigating to the new page
        }
    }
    public class MyPageRenderer : PageRenderer
    {
        public MyPageRenderer()
        {
            var mySettings = ( App as PrismApplication ).Container.Resolve<IMySettings>();
            // Use MySettings to set the property you need to set
        }
