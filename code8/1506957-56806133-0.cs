    public sealed class SessionManager
    {
        static readonly Lazy<SessionManager> lazy =
            new Lazy<SessionManager>(() => new SessionManager());
        public static SessionManager Instance { get { return lazy.Value; } }
        private Stopwatch StopWatch = new Stopwatch();
        SessionManager()
        {
            SessionDuration = TimeSpan.FromMinutes(5);
        }
        public TimeSpan SessionDuration;
        public void EndTrackSession()
        {
            if (StopWatch.IsRunning)
            {
                StopWatch.Stop();
            }
        }
        public void ExtendSession()
        {
            if (StopWatch.IsRunning)
            {
                StopWatch.Restart();
            }
        }
        public void StartTrackSessionAsync()
        {
            if (!StopWatch.IsRunning)
            {
                StopWatch.Restart();
            }
            Xamarin.Forms.Device.StartTimer(new TimeSpan(0, 0, 2), () =>
            {
                if (StopWatch.IsRunning && StopWatch.Elapsed.Minutes >= SessionDuration.Minutes)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Prism.PrismApplicationBase.Current.Container.Resolve<INavigationService>().NavigateAsync("/Index/Navigation/LoginPage");
                    });
                    StopWatch.Stop();
                }
                return true;
            });
        }
    }
