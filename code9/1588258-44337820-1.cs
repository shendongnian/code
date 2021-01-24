    class MainViewModel : ReactiveObject, ISupportsActivation
    {
        public ViewModelActivator Activator => _activator;
        private ViewModelActivator _activator = new ViewModelActivator();
    
        public MainViewModel()
        {
            this.WhenActivated(d =>
            {
                // This will be called
            });
        }
    }
