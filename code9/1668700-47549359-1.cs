    public async Task CheckPing(TextBox TextBox_Drukarki_IP)
    {
        try
        {
            var text = TextBox_Drukarki_IP.Text; // get TextBox.Text in UI thread
            if (!string.IsNullOrWhiteSpace(text))
            {
                //Now the Ping.Send is running in Background
                PingReply PingOdp = await Task.Run(() => 
                {
                     Ping PingZapytanie = new Ping();
                     return PingZapytanie.Send(text);
                });
                
                //This code is running on the UI Thread again (because you access a FrameworkElement)
                if (PingOdp.Status == IPStatus.Success)
                {
                    TextBox_Drukarki_IP.Background = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    TextBox_Drukarki_IP.Background = new SolidColorBrush(Colors.Red);
                }
            }
        }
        catch (Exception e)
        {
            var window = Application.Current.Windows.OfType<MetroWindow>().FirstOrDefault();
            if (window != null)
                await window.ShowMessageAsync("Błąd!", e.Message);
            return;
        }
    }
