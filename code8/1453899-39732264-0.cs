    public static class AppHost
        {
            private static readonly object AppLock = Guid.NewGuid();
            private static Application _application;
            private static ResourceDictionary _currentTheme;
            private static ResourceDictionary _controlDictionary;
            private static ResourceDictionary _resourceDictionary;
            private static Dictionary<string, ResourceDictionary> _themes;
            private static KryptonManager _kryptonManager;
            private static IMessenger _messengerInstance;
    
            /// <summary>
            /// Gets or sets an instance of a <see cref="IMessenger" /> used to
            /// broadcast messages to other objects. If null, this class will
            /// attempt to broadcast using the Messenger's default instance.
            /// </summary>
            private static IMessenger MessengerInstance
            {
                get
                {
                    return _messengerInstance ?? Messenger.Default;
                }
                set
                {
                    _messengerInstance = value;
                }
            }
    
            public static Application CurrentApplication
            {
                get
                {
                    lock (AppLock)
                    {
                        if (_application == null)
                        {
                            _application = new Application();
    
                            LoadDictionaries();
                            InitializeApplication();
                            ChangeTheme(PaletteModeManager.Custom);
    
                            KryptonManager.GlobalPaletteChanged += KryptonManagerGlobalPaletteChanged;
                            _kryptonManager = new KryptonManager();
                        }
                    }
    
                    return _application;
                }
            }
    
            private static void KryptonManagerGlobalPaletteChanged(object sender, EventArgs e)
            {
                ChangeTheme(_kryptonManager.GlobalPaletteMode);
            }
    
            private static void InitializeApplication()
            {
                Application.Current.Resources.MergedDictionaries.Add(_resourceDictionary);
                Application.Current.Resources.MergedDictionaries.Add(_controlDictionary);
            }
    
            public static void ChangeTheme(PaletteModeManager manager)
            {
                Application.Current.Resources.MergedDictionaries.Remove(_currentTheme);
    
                switch (manager)
                {
                    case PaletteModeManager.Office2007Blue:
                        _currentTheme = _themes["Office2007BlueStyle"];
                        Application.Current.Resources.MergedDictionaries.Add(_currentTheme);
                        break;
                    case PaletteModeManager.Office2007Black:
                        _currentTheme = _themes["Office2007BlackStyle"];
                        Application.Current.Resources.MergedDictionaries.Add(_currentTheme);
                        break;
                    default:
                        _currentTheme = _themes["Office2007BlueStyle"];
                        Application.Current.Resources.MergedDictionaries.Add(_currentTheme);
                        break;
                }
    
                MessengerInstance.Send(new ThemeChangedMessage());
            }
    
            private static void LoadDictionaries()
            {
                _resourceDictionary =
                    Application.LoadComponent(new Uri(@"/ApplicationHost;component/Resources/ResourceDictionary.xaml",
                        UriKind.Relative)) as ResourceDictionary;
                _controlDictionary =
                    Application.LoadComponent(new Uri(@"/ApplicationHost;component/Resources/UserControlResourceDictionary.xaml",
                        UriKind.Relative)) as ResourceDictionary;
                _themes = new Dictionary<string, ResourceDictionary>
                {
                    {
                        "Office2007BlueStyle",
                        Application.LoadComponent(
                                new Uri(@"/ApplicationHost;component/Resources/Office2007BlueStyle.xaml",
                                    UriKind.Relative))
                            as ResourceDictionary
                    },
                    {
                        "Office2007BlackStyle",
                        Application.LoadComponent(
                                new Uri(@"/ApplicationHost;component/Resources/Office2007BlackStyle.xaml",
                                    UriKind.Relative))
                            as ResourceDictionary
                    }
                };
            }
        }
