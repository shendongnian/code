    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            string[] arguments = new string[] { @"window.getSelection().toString();" };
            var s = await wv.InvokeScriptAsync("eval", arguments);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
