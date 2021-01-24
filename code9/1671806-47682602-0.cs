    public class SharedController : IControlSomething
    {
        private string _sharedValue;
        public string SharedValue
        {
            get => _sharedValue;
            set
            {
                if (_sharedValue == value)
                    return;
                _sharedValue = value;
                OnSharedValueUpdated();
            }
        }
        public event EventHandler SharedValueUpdated;
        protected virtual void OnSharedValueUpdated()
        {
            SharedValueUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
    public class ViewModel1
    {
        private readonly IControlSomething _controller;
        public ViewModel1(IControlSomething controller)
        {
            // Save to access controller values in commands
            _controller = controller;
            _controller.SharedValueUpdated += (sender, args) =>
            {
                // Handle value update event
            };
        }
    }
    public class ViewModel2
    {
        private readonly IControlSomething _controller;
        public ViewModel2(IControlSomething controller)
        {
            // Save to access controller values in commands
            _controller = controller;
            _controller.SharedValueUpdated += (sender, args) =>
            {
                // Handle value update event
            };
        }
    }
