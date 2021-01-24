    public partial class App : Application
    {
        private void App_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                ViewModel vm = new ViewModel();
                MainWindow w = new MainWindow(vm);
                Window1 w1 = new Window1(vm);
                w.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
