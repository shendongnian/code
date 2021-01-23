     private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            await Scanner();
        }
      private static async Task Scanner()
        {
            try
            {
                await Task.Run(() =>
                {
                     BigBox.DoScan();
                });
            }
            catch (Exception ex)
            {
               SMErrorLog.WriteLog("Scanner error: ", ex);
            }
        }
