    private event EventHandler Update = delegate { };
    private async void OnUpdate(object sender, EventArgs e) {
        await Task.Delay(10000);//Non blocking delay on other thread
        //Back on the UI thread
        dotsLoaderView.Hide();
        imgOverlay.Visibility = ViewStates.Gone;
        ll_Info.Visibility = ViewStates.Visible;
        txt_Info.Text = "Some mesage !";
    }
