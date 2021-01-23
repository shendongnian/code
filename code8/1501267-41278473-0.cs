    CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    CancellationToken _ct;
    
    private void Submit()
    {
         _ct = cancellationTokenSource.Token;
        var task = Task.Factory.StartNew(() =>
        {
          _ct.ThrowIfCancellationRequested();
          //your code here
        }, _ct);
        
    
    }
    private void button_Click(object sender, EventArgs e)
    {
        //Some code here
       _cancellationTokenSource.Cancel();
    }
