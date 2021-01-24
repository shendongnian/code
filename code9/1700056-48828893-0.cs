    private bool _handle = true;
    private void val_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (_handle)
        {
            _handle = false;
            Slider slider = sender as Slider;
            slider.Value = Math.Round(e.NewValue / 2.0) * 2.0;
            _handle = true;
        }
    }
