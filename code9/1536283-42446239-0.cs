    public async Task LoadData()
    {
      // do something DB intensive
    }
    public async Task HandleLoadExceptions()
    {  
        try
        {
            await LoadData();
        }
        catch (Exception E)
        {
            // handle exception
        }
    }
