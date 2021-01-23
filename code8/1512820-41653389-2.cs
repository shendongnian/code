    private void buttonPin_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs e)
	{
		// toggle the state of the LED every time the button is pressed
		if (e.Edge == GpioPinEdge.FallingEdge)
		{
			ledPinValue = (ledPinValue == GpioPinValue.Low) ? 
			GpioPinValue.High : GpioPinValue.Low;
			ledPin.Write(ledPinValue);
		}
	[...]
