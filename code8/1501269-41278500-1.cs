    using System.Threading.Tasks;
    
    private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    
    private async Task Submit()
    {
    	var cancellationToken = this.cancellationTokenSource.Token;
    	await Task.Factory.StartNew(() => 
    	{
    		cancellationToken .ThrowIfCancellationRequested();
            // Blocking code, network requests...
    	}, this.cancellationTokenSource.Token); 
    }
    
    private void button_Click(object sender, EventArgs e)
    {
    	this.cancellationTokenSource.Cancel();
    }
