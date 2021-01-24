    public MainPage()
            {
                
                Window.Current.Dispatcher.AcceleratorKeyActivated += Dispatcher_AcceleratorKeyActivated;
    
                this.InitializeComponent();
            }
    
            private void Dispatcher_AcceleratorKeyActivated(Windows.UI.Core.CoreDispatcher sender, Windows.UI.Core.AcceleratorKeyEventArgs args)
            {
                var eT = args.EventType;
                if (CoreAcceleratorKeyEventType.KeyUp == eT)
                {
                    var key = args.VirtualKey.ToString();
                    switch (key)
                    {
                        case "Enter" :
                            //Do something
                            break;
                        case "255" :
                            //Do something
                            break;
                        default:
                            break;
                    }
                }
            }
