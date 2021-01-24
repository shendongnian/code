    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void btnRun_Click(object sender, RoutedEventArgs e)
        {
            await MethodOneCaller();
            await MethodTwoCaller();
            MessageBox.Show("COMPLETED!");
        }
        private async Task MethodOneCaller()
        {
            ProgressBarWindow pbWindowOne =
                new ProgressBarWindow("Running Method One") { Owner = this };
            pbWindowOne.Show();
            await Utility.TimeConsumingMethodOne(i => pbWindowOne.SetProgressUpdate(i));
        }
        private async Task MethodTwoCaller()
        {
            ProgressBarWindow pbWindowTwo =
                new ProgressBarWindow("Running Method Two") { Owner = this };
            pbWindowTwo.Show();
            await Utility.TimeConsumingMethodTwo(i => pbWindowTwo.SetProgressUpdate(i));
        }
    }
