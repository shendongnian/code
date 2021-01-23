    private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                () =>
                {
                    statustextblk.Text = "Offline sync in progress...";
                }
                );
            
            Debug.WriteLine("Refresh started");
            await Task.Delay(1000);
            //RefreshSuccess = true;
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            async () =>
            {
                statustextblk.Text = "Offline sync completed...";
                await Task.Delay(1000);
                statustextblk.Text = "";
            }
            );
        }
