    protected virtual void PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs e)
    {
       PrintTask printTask = null;
       printTask = e.Request.CreatePrintTask("C# Printing SDK Sample", sourceRequested =>
       {
             // Print Task event handler is invoked when the print job is completed.
             printTask.Completed += async (s, args) =>
             {
                //was print task canceled?
                if (args.Completion == PrintTaskCompletion.Canceled)
                {
                   await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                   {
                       MessageDialog dlg = new MessageDialog( "Printing canceled" );
                       dlg.ShowAsync();
                   });
                }
             };
    
             sourceRequested.SetSource(printDocumentSource);
       });
    }
