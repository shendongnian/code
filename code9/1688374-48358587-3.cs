    namespace WpfApp1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            async void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                Window w = new ProgressWindow();
    
                var task = Task.Run(() => Go(w));
                w.ShowDialog();
                await task;
            }
    
            async protected void Go(Window w)
            {
                await Task.Delay(2000);
                //MessageBox.Show("Completed!"); // it doesn't really need - only for indication purpose
                Dispatcher.BeginInvoke(
                    new Action(() =>
                    {
                        w.Close();
                    }));
            }
        }
    }
