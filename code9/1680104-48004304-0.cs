    namespace WpfDemos
    {
        public partial class App : Application
        {
            public static Window CurrentMainWindow
            {
                get { return Current.MainWindow; }
            }
        }
    }
