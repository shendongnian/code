    Task.Run(async () =>
    {
         //this part is run on a background thread...
         await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, 
            ()=> 
            {
                 //this part is being executed back on the UI thread...
                 GeneralMessage.Text = "Message Complete!";
            });
    });
