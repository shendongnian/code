    async void OnClickSomePage()
       {
         if(CrossConnectivity.Current.IsConnected)
    {
         //Navigate
    }
    else
    {
        // Display a message
        await DisplayAlert("No internet", "", "Ok");
    }
       }
