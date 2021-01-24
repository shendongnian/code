	private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	{
		GetColour();
	}
	public void GetColour()
	{
		byte rr = (byte)slider1.Value;
		byte gg = (byte)slider2.Value;
		byte bb = (byte)slider3.Value;
		Color cc = Color.FromRgb(rr, gg, bb);
		SolidColorBrush colorBrush = new SolidColorBrush(cc);
		stackPanel1.Background = colorBrush;
		MyColour.Text = colorBrush.Color.ToString();
	}
