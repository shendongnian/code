    public class ShellViewModel : Screen, IScreen, IHandle<EventMessage>
    {
        private readonly IEventAggregator _eventAggregator;
        public ShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }
        public void OpenWindow()
        {
            WindowManager wm = new WindowManager();
            SecondWindowViewModel swm = new SecondWindowViewModel(_eventAggregator);
            wm.ShowWindow(swm);
        }
        public void Handle(EventMessage message)
        {
            MessageBox.Show(message.Text);
        }
    }
