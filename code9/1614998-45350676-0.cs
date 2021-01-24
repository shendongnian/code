    public async Task GetStocks(string texboxText)
    {
        Task.Run(() => { 
           IsBusy = true;
           CreateCollection(texboxText); 
           IsBusy = false;
        });
    }
