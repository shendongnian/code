    public void Update()
    {
        Task.Delay(10000).ContinueWith(t =>
        {
            dotsLoaderView.Hide();
            RunOnUiThread(delegate
            {
                imgOverlay.Visibility = ViewStates.Gone;
                ll_Info.Visibility = ViewStates.Visible; 
                txt_Info.Text = "Some mesage !";
            });
        });
    }
