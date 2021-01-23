    public void GPIO_ProgressUpdate(object sender, EventArgs e)
    {
    await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
        {
            service_data = await Service.wsClient.GetDataFromServicetoUpdateUI(parameter);
            // UI-update
            txtUpdate.Text = service_data.ToString();
        });
    }
