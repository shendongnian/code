    public class MainViewModel : INotifyPropertyChanged
        {
    
            private IControlView _control;
            public IControlView Control
            {
                get
                {
                    return _control;
                }
                set
                {
                    _control = value;
                    OnPropertyChanged();
                }
            }
    
            public MainViewModel()
            {   //Subscribe for the ViewService event:   
                ViewService<IControlView>.GetContainer.Show += ShowControl;
                // in this way, here is how to set a user control to the window.
                ViewService<IControlView>.GetContainer.ShowControl<ListViewDatabaseStyle>(new TheViewModel(yourDependencyItems));
               //you can call this anywhere in your viewmodel project. For example inside a command too.
            }
    
            public void ShowControl(IControlView ControlView)
            {
                Control = ControlView;
            }
            //implement INotifyPropertyChanged...
            protected void OnPropertyChanged([CallerMemberName] string name = "propertyName")
            {
               PropertyChangedEventHandler handler = PropertyChanged;
               if (handler != null)
               {
                   handler(this, new PropertyChangedEventArgs(name));
               }
            }
               public event PropertyChangedEventHandler PropertyChanged;
        }
