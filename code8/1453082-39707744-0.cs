    private void Test()
    {
        Device.BeginInvokeOnMainThread(SomeMethod);
    }
    private async void SomeMethod()
    {
        try
        {
            await SomeAsyncMethod();
        }
        catch (Exception e) // handle whatever exceptions you expect
        {
            //Handle exceptions
        }
    }
    private async Task SomeAsyncMethod()
    {
        await Navigation.PushModalAsync(new ContentPage());
    }
