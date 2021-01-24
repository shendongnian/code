    private TaskCompletionSource<object> _event = new TaskCompletionSource<object>();
    
    //You are only allowed to do async void if you are writing a event handler!
    public async void PrimeButton_OnClick(object sender, EventArgs e)
    {
        //I moved the code in to Example() so the async void would not be a distraction.
        await Example();
    }
    
    public async Task Example()
    {
        await _event.Task;
        MessageBox.Show("Run Clicked");
    }
    
    public async void RunButton_OnClick(object sender, EventArgs e)
    {
        _event.SetResult(null);
    }
