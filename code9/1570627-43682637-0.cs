    private async void RunAllScriptsChildwdwBtnOK_Click(object sender, RoutedEventArgs e)
    {
        //TODO  ... Start loading indicator
    
        await Task.Run(async ()=> 
        {
            await Application.Current.Dispatcher.InvokeAsync(()=>
            {
                _RunAllScripts_Click();
            });
        });
    
        //TODO  ... End loading indicator
    }
