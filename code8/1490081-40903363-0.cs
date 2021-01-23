        _btnBlue = _gpioController.OpenPin(BTNBLUE);
        _btnBlue.ValueChanged += btnValueChanged;
        public void btnValueChanged(GpioPin pin, GpioPinValueChangedEventArgs e)
        {
            if (_btnBlue.Read() == GpioPinValue.Low)
            {
                isBlueButtonPressed = true;
            }
        }
