    public class TimeExtension : MarkupExtension, INotifyPropertyChanged
    {
        System.Threading.Timer _timer = null;
        public TimeExtension() { }
        public TimeExtension(TimeSpan interval)
        {
            Interval = interval;
        }
        public TimeSpan Interval { get; set; } = new TimeSpan(0, 0, 0, 0, 250);
        #region CurrentTime Property
        private DateTime _currentTime = default(DateTime);
        public DateTime CurrentTime
        {
            get { return _currentTime; }
            set
            {
                if (value != _currentTime)
                {
                    _currentTime = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion CurrentTime Property
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] String propName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            IProvideValueTarget provideValueTarget =
                serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            if (provideValueTarget.TargetObject is DependencyObject targetobj)
            {
                if (provideValueTarget.TargetProperty is DependencyProperty targetProp)
                {
                    System.Threading.TimerCallback tick
                        = new System.Threading.TimerCallback(o =>
                        {
                            try
                            {
                                CurrentTime = DateTime.Now;
                            }
                            catch (Exception ex)
                            {
                                _timer.Dispose();
                                _timer = null;
                            }
                        });
                    _timer = new System.Threading.Timer(tick, null, 0, (int)Interval.TotalMilliseconds);
                }
            }
            return (new Binding("CurrentTime") { Source = this }).ProvideValue(serviceProvider);
        }
    }
