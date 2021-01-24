    protected override OnAppearing(){
        base.OnAppearing();
    
        Task.Run(async()=>{
            try
            {
                // Use VM and Binding... 
                MyVM.Data = (await GoGetTheData ()).Stuff;
            }
            catch (Exception e)
            {
    
                // Here I think you should use Device.BeginInvokeOnMainThread();
                MyVm.Data = "Narg";
            }
        });
    }
