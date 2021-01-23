    using System.Threading;
    using Window.UI.Xaml;
    using Window.UI.Xaml.Controls;
    namespace UniversalTimerApp
    {
        public sealed partial class MainPage : Page
        {
            private Timer questionTimer;
            public MainPage()
            {
                this.InitializeComponent();
                this.questionTimer = new Timer(this.EndOfTimer, null, Timeout.Infinite, Timeout.Infinite);
            }
            private void StartButton_Click(object sender, RoutedEventArgs e)
            {
                this.questionTimer.Change(3000, Timeout.Infinite);
                this.StatusText.Text = "Timer Started!";
            }
            private async void EndOfTimer(object state)
            {
                await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    this.InputField.IsEnabled = false;
                    this.StatusText.Text = "Timer Ended.";
                });
            }
        }
    }
