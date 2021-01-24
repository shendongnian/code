    void Main()
    {
                var cancelSource = new CancellationTokenSource();
    
                Action action1 = async () =>
                {
                    await GetMessages();
                };
    
                Action action2 = async () =>
                {
                    //wait for filling the GetOrderBookData
                    await GetOrderBookData();
                    //on this point you should have the data to refresh on the grid
                    UpdateOrderBook();
                };
                
                Task task1 = Task.Factory.StartNew(action1, cancelSource.Token);
                Task task2 = Task.Factory.StartNew(action2, cancelSource.Token);
    
                //when you want to cancel the task just call Cancel over cancelSource  => cancelSource.Cancel();
    
                Task.WhenAll(task1, task2).Wait();
    }
    //Be sure to mark your methods with the async keyword
    private async Task UpdateOrderBook()
    {
    ...
    }
    private async Task GetOrderBookData()
    {
     ....
    }
    private async Task GetMessages()
    {
     ....
    }
