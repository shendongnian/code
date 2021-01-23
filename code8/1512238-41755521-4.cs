    public class MainPageViewModel : INavigationAware
    {
        IEventAggregator _ea { get; }
        public MainPageViewModel( IEventAggregator ea )
        {
            _ea = ea;
        }
        public void OnNavigatedTo( NavigationParameters parameters )
        {
            _ea.GetEvent<MyEvent>().Publish( parameters[ "message" ].ToString() );
        }
    }
    public class MyPageRenderer : PageRenderer
    {
        public MyPageRenderer()
        {
            var ea = ( App as PrismApplication ).Container.Resolve<IEventAggregator>();
            ea.GetEvent<MyEvent>().Subscribe( OnMyEvent );
        }
        public void OnMyEvent( string message )
        {
            // Do what you need to
        }
    }
