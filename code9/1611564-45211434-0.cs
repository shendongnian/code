    public async void ProgressSliderEvent(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
    {
        if (e.NewValue > e.OldValue)
        {
            double diff = e.NewValue - e.OldValue;
            for (double d = 0; d < diff; ++d)
            {
                await this.mainWindow.DisplayNewPoint();
            }
        }
        else if (e.OldValue > e.NewValue)
        {
            double diff = e.OldValue - e.NewValue;
            for (double d = 0; d < diff; ++d)
            {
                await this.mainWindow.DisplayNewPoint();
            }
        }
        this.mainWindow.UpdateGUI(e.NewValue);
    }
