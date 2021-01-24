    protected override OnAppearing(){
        base.OnAppearing();
    
        Task.Run(async()=>{
            try
            {
                MyLabel.Text = (await GoGetTheData ()).Stuff;
            }
            catch (Exception e)
            {
    
                // Here I think you should use Device.BeginInvokeOnMainThread();
                MyLabel.Text = "Narg";
            }
        });
    }
