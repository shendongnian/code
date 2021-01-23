    using System;
    using System.Threading;
    using System.Windows;
    
    namespace SO40189046
    {
      /// <summary>
      /// Interaction logic for MainWindow.xaml
      /// </summary>
      public partial class MainWindow : Window
      {
        public MainWindow()
        {
          InitializeComponent();
          Loaded += MainWindow_Loaded;
    
          // Background thread initializing the MainWindow
          ThreadPool.QueueUserWorkItem((state) =>
          {
            for (int i = 0; i < 10; i++)
            {
              Dispatcher.Invoke(() =>
              {
                TimeText.Text = DateTime.Now.ToString();
              });
              Thread.Sleep(1000);
            }
          });
    
        }
    
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
    
          LoginWindow login = new LoginWindow();
          login.Owner = App.Current.MainWindow;
          login.WindowStartupLocation = WindowStartupLocation.CenterOwner;
          if (!login.ShowDialog().GetValueOrDefault())
          {
            Close();
          }
        }
      }
    }
