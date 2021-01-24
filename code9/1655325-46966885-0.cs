    private static int _i = 0;
    private static int _lastResult = 0;
    public async Task<int> Calculate() {    
        _lastResult = await CalculateNextAsync();
        return _lastResult;
    }
    
    //No need to wrap the code in a Task.Run. Just await the async code
    private static async Task<int> CalculateNextAsync()  
        await Task.Delay(2000);
        return ++_i;
    }
    
    //Event Handlers allow for async void
    private async void Button_Click(object sender, RoutedEventArgs e) {
        while( true) {
            var result = await Calculate();
            Debug.WriteLine(result.ToString());
        }
    }
