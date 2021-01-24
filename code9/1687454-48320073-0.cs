    var timer = new System.Threading.Timer((timer_e) =>
    {
        Application.Current.Dispatcher.Invoke(new Action(() => {
            textBoxResult.Text = "";
            device.Service.Inputs = textBoxRun.Text;
            device.Service.Run(device.ResourceStore.Resources);
        }
    }, null, startTimeSpan, periodTimeSpan);
