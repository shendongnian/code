    public partial class Window25 : Window
    {
        public Window25()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                Progress<long> progress = null;
                progress = new Progress<long>((i) =>
                {
                    try
                    {
                        // Update ProgressBar 
                        Dispatcher.Invoke(() => { PBar.Value = i; });
                    }
                        // handle pre-mature closing of window (task cancellation)
                    catch { }
                });
                Controller c = new Controller(progress);
                c.Do();
            }
            );
        }
    }
    public class Controller
    {
        Progress<long> _progress;
        public Controller(Progress<long> progress)
        {
            _progress = progress;
        }
        public void Do()
        {
            for (long s = 0; s < 99999; ++s)
                ((IProgress<long>)(_progress)).Report((long)s);
        }
    }
