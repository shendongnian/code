    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        async void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window w = new ProgressWindow();
            Task work = Task.Run(() => Go(w));
            w.ShowDialog();
            await work;
        }
    
        void Go(Window w)
        {
            Thread.Sleep(2000); // imitate some work
            Dispatcher.BeginInvoke(
                new Action(() =>
                {
                    w.Close();
                }));
        }
    }
