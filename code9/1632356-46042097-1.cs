    private async void TrackBtn_Clicked(object sender, EventArgs e)
    {
        MainViewModel vm = this.BindingContext as MainViewModel;
        await vm.GetShippingDataAsync(TrackIDText.Text);
    }
