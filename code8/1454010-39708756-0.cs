    public class MyEvent : PubSubEvent<string> { }
    public class MyViewModel
    {
    private readonly IEventAggregator _eventAggregator = new EventAggregator();
    public MyViewModel()
    {
        _eventAggregator.GetEvent<MyEvent>().Subscribe(GetMessage);
    }
    private void GetMessage(string text)
    {
        MessageBox.Show(text);
    }
    private DelegateCommand _pressButtonCommand;
    public DelegateCommand PressButtonCommand
    {
        get
        {
            return _pressButtonCommand ?? (_pressButtonCommand = new DelegateCommand(PressButton));
        }
    }
    private void PressButton()
    {
        _eventAggregator.GetEvent<MyEvent>().Publish("Hello World");
    }
    }
