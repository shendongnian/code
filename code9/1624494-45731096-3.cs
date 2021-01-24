    private void SomeMethod(IProgress<string> progress)
    {
       foreach(...)
       {
           progress.Report("foo");
           ....
       }
    }
    private async void myButton_Click(object sender, RoutedEventArgs e)
    {
        var progressIndicator = new Progress<string>(reportProgressMethod);
        try
        {
            await Task.Run(()=>someMethod(progressIndicator());
        }
        catch(Exception e)
        {
            ModernDialog.ShowMessage(e.ToString());
        }
    }
