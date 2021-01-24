    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        async void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window w = new ProgressWindow();
	        Task work = Go(w);
	        w.ShowDialog();
	        await work; // exceptions in unawaited task are difficult to handle, so let us await it here.
        }
        async Task Go(Window w)
        {
            await Task.Delay(500);    
            w.Close();
        }
    }
