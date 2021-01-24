    private async void meterNumberBox_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == Windows.System.VirtualKey.Enter)
        {
            if (e.KeyStatus.RepeatCount == 1)
            {
                singlescan = meterNumberBox.Text + ",";
                meternumber += singlescan;
                singlescan = "";
                meterNumberBox.Text = "";
            }
        }
    }
