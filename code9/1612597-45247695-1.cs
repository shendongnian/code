    public partial class MainWindow : Window
    {
        public enum MethodType
        {
            One,
            Two
        }
        private ProgressBarWindow pbWindowOne = null;
        private ProgressBarWindow pbWindowTwo = null;
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void btnRun_Click(object sender, RoutedEventArgs e)
        {
            await RunMethodCallers(sender, MethodType.One);
            await RunMethodCallers(sender, MethodType.Two);
            MessageBox.Show("COMPLETED!");
        }
        private async Task RunMethodCallers(object sender, MethodType type)
        {
            IProgress<int> progress;
            switch (type)
            {
                case MethodType.One:
                    progress = new Progress<int>(i => pbWindowOne.SetProgressUpdate(i));
                    await Task.Run(() => MethodOneCaller(progress));
                    break;
                case MethodType.Two:
                    progress = new Progress<int>(i => pbWindowTwo.SetProgressUpdate(i));
                    await Task.Run(() => MethodTwoCaller(progress));
                    break;
            }
        }
        private void MethodOneCaller(IProgress<int> progress)
        {
            Dispatcher.Invoke(() =>
            {
                pbWindowOne = new ProgressBarWindow("Running Method One");
                pbWindowOne.Owner = this;
                pbWindowOne.Show();
            });
            Utility.TimeConsumingMethodOne(progress);
        }
        private void MethodTwoCaller(IProgress<int> progress)
        {
            Dispatcher.Invoke(() =>
            {
                pbWindowTwo = new ProgressBarWindow("Running Method Two");
                pbWindowTwo.Owner = this;
                pbWindowTwo.Show();
            });
            Utility.TimeConsumingMethodTwo(progress);
        }
    }
