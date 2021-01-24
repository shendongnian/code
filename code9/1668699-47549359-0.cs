    public async Task CheckPing(TextBox TextBox_Drukarki_IP)
    {
    
        try
        {
            if (TextBox_Drukarki_IP.Text == "" || TextBox_Drukarki_IP.Text == " ")
            {
                return;
            }
            else
            {
                //Now the Ping.Send is running in Background
                PingReply PingOdp = await Task.Run(() => 
                {
                    Ping PingZapytanie = new Ping();
                     return PingZapytanie.Send(TextBox_Drukarki_IP.Text);
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
