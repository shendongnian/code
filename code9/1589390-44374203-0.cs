    [Export(typeof(IShell))]
    public class ShellViewModel : IShell, PropertyChangedBase
    {
        string _myMessage;
        public string MyMessage
        {
            get { return _myMessage; }
            set
            {
                _myMessage = value;
                NotifyOfPropertyChange(() => MyMessage);
            }
        }
        public IEnumerable<IResult> DoSomething()
        {
            yield return Loader.Show("Loading...");
            yield return Task.Delay(1000).AsResult();
            yield return Loader.Hide();
        }
    }
