    public sealed partial class MainPage : Page
    {
            
        private BluetoothLEAdvertisementWatcher watcher = null;
        private IAsyncOperation<IUICommand> _bluetoothNotOnDialogOperation;
        public MainPage()
        {
            this.InitializeComponent();
            watcher = new BluetoothLEAdvertisementWatcher();
            watcher.ScanningMode = BluetoothLEScanningMode.Active;
            textBlock.Text = watcher.Status.ToString();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            watcher.Received += OnAdvertisementReceived;
            watcher.Stopped += OnAdvertisementWatcherStopped;
        }
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            watcher.Stop();
        }
        private async void OnAdvertisementReceived(BluetoothLEAdvertisementWatcher watcher, BluetoothLEAdvertisementReceivedEventArgs eventArgs)
        {
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                textBlock.Text = "rcvd" + watcher.Status.ToString();
            });
        }
        private async void OnAdvertisementWatcherStopped(BluetoothLEAdvertisementWatcher watcher, BluetoothLEAdvertisementWatcherStoppedEventArgs eventArgs)
        {
            if (watcher .Status == BluetoothLEAdvertisementWatcherStatus.Aborted && _bluetoothNotOnDialogOperation == null)
            {
                MessageDialog messageDialog = new MessageDialog(
                    "Do you wish to enable Bluetooth on this device?",
                    "Failed to start Bluetooth LE advertisement watcher");
                messageDialog.Commands.Add(new UICommand("Yes",
                    async command => { await LaunchBluetoothSettingsAsync(); }));
                messageDialog.Commands.Add(new UICommand("No",
                    command => { watcher.Stop(); }));
                _bluetoothNotOnDialogOperation = messageDialog.ShowAsync();
            }
        }
        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            watcher.Start();
            textBlock.Text = watcher.Status.ToString();
        }
        private void buttonStop_Click(object sender, RoutedEventArgs e)
        {
            watcher.Stop();
            textBlock.Text = watcher.Status.ToString();
        }
        private void buttonView_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = watcher.Status.ToString();
        }
        private async Task LaunchBluetoothSettingsAsync()
        {
            await Launcher.LaunchUriAsync(new Uri("ms-settings-bluetooth:"));
        }
    }
