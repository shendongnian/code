    public class MianViewModel : BindableBase
    {
        public ICommand ClickCommand
        {
            get;
            private set;
        }
        public MianViewModel()
        {
            ClickCommand = new DelegateCommand<object>(ClickedMethod);
        }
        private async void ClickedMethod(object obj)
        {
            var devicePicker = new DevicePicker();
            devicePicker.Filter.SupportedDeviceSelectors.Add(BluetoothLEDevice.GetDeviceSelectorFromPairingState(true));
            // Calculate the position to show the picker (right below the buttons)
            Button DiscoverButton = obj as Button;
            if (DiscoverButton != null)
            {
                var ge = DiscoverButton.TransformToVisual(null);
                var point = ge.TransformPoint(new Point());
                var rect = new Rect(point, new Point(100, 100));
                var device = await devicePicker.PickSingleDeviceAsync(rect);
                if (device != null)
                {
                    var bluetoothLEDevice = await BluetoothLEDevice.FromIdAsync(device.Id);
                }
            }
        }
    }
