    async void OnPinClicked(object sender, EventArgs e)
    {
        var pin = sender as Pin;
     
        if (pin != null)
        {
            await Navigation.PushAsync(new MyPage(pin.Index));
        }
    }
