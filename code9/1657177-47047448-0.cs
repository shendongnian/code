    public partial class App : Application
    {
        public MainWindow window = new MainWindow();
        void App_Startup(object sender, StartupEventArgs e)
        {
            window.Show();
            window.Closing += manageClosing;
        }
        void manageClosing(Object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("It won't close");
            e.Cancel = true;
        }
    }
