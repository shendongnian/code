        private static GpioPin pin;
        public static void Sniff(uint gpioPinNumb)
        {
            Task.Run(() => {
                    pin = GpioController.GetDefault().OpenPin((int)gpioPinNumb, GpioSharingMode.Exclusive);
                    pin.SetDriveMode(GpioPinDriveMode.Input);
                        ...
                        ...
