    namespace WpfTest
    {
      /// <summary>
      /// Interaction logic for App.xaml
      /// </summary>
      public partial class App : Application
      {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
           frmStudent frm = new frmStudent();
           frm.ShowDialog();
        }
      }
    }
