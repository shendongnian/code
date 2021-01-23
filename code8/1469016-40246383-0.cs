    async void SomeEventHandler()
    {
    // called from the UI thread (or its equivalent in Xamarin)
        await FillCalendarWindows();
    }
    protected async Task FillCalendarWindows()
        {
            try
            {
               //create 7*6 = 42 labels and buttons
			   
                await CallWebService(StartDate.Month, StartDate.Year);
               
            }
            catch (Exception e)
            {
            }
        }
		
    public async Task CallWebService(int Month, int Year)
        {
            try
            {
                await GetResponseFromWebService.GetResponse... ;
				
                // .... same code as in your example 
				
                ChangeCalendar(....);
                
            }
            catch /*... */
            {
            }
        } 
		
    protected void ChangeCalendar(int changes)
        {
            try
            {
                /* no need to do Device.BeginInvokeOnMainThread () so you can replace all that with normal calls*/
            }
            catch (Exception e)
            {
				/* ... */
            }
        }
