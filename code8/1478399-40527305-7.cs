    using System.Windows;
    
    namespace WpfApplication1
    {
       /// <summary>
       /// Interaction logic for App.xaml
       /// </summary>
       public partial class App : Application
       {
          protected override void OnStartup(StartupEventArgs e)
          {
             base.OnStartup(e);
             ShutdownMode = ShutdownMode.OnExplicitShutdown;
             var loginWindow = new Login();
             loginWindow.ShowDialog();
             if (!loginWindow.LoggedIn)
             {
                Shutdown();
                return;
             }
             ShutdownMode = ShutdownMode.OnLastWindowClose;
          }
       }
    }
