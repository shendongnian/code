    namespace ApplicationB
    {
        /// <summary>
        /// Interaction logic for App.xaml
        /// </summary>
        public partial class App : Application
        {
            private SecondaryAppHelper _secondaryApp;
    
            protected override void OnStartup ( StartupEventArgs e )
            {
                _secondaryApp = new SecondaryAppHelper ( );
            }
            protected override void OnExit ( ExitEventArgs e )
            {
                _secondaryApp.Dispose ( );
            }
        }
    
        sealed class SecondaryAppHelper : IDisposable
        {
            private const string _secondaryDomainName = "ApplicationA Domain";
            private AppDomain _domain;
    
            public SecondaryAppHelper ( )
            {
                var setup = new AppDomainSetup ( ) { ApplicationBase    = AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                                                     ConfigurationFile  = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, // Here we share the same app.config
                                                     ApplicationName    = AppDomain.CurrentDomain.SetupInformation.ApplicationName,
                                                     LoaderOptimization = LoaderOptimization.MultiDomainHost };
    
                _domain = AppDomain.CreateDomain ( _secondaryDomainName, null, setup );
    
                // Let's ask our new domain to launch ApplicationA
                // Without creating a new domain, the two WPF windows would share the same render thread.
                _domain.DoCallBack ( ( ) =>
                    {
                        var thread = new Thread ( ( ) =>
                        {
                            var app = new ApplicationA.App ( );
                            var win = new ApplicationA.MainWindow ( );
    
                            app.MainWindow = win;
    
                            app.Startup += ( sender, e ) => { (sender as ApplicationA.App).MainWindow.Show ( ); };
                            app.Run ( );
                        } );
    
                        thread.SetApartmentState ( ApartmentState.STA ); // Necessary for WPF & WinForms
                        thread.IsBackground = true; // The thread will terminate itself nicely after the app closes
                        thread.Start ( );
                    } );
            }
    
            public void Dispose ( )
            {
                _domain.DoCallBack ( ( ) =>
                    {
                        if ( Application.Current != null )
                        {
                            EventHandler handler = null;
    
                            handler = ( sender, e ) =>
                                {
                                    var dispatcher = sender as Dispatcher;
                                    dispatcher.ShutdownFinished -= handler;  // Better safe than sorry
    
                                     AppDomain.Unload ( AppDomain.CurrentDomain );
                                };
    
                            Application.Current.Dispatcher.ShutdownFinished += handler;
    
                            Application.Current.Dispatcher.BeginInvokeShutdown ( DispatcherPriority.Background );
                        }
                    } );
            }
        }
    }
