    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    CancellationTokenSource cancellationTokenSource =
    new CancellationTokenSource();
    
    CancellationToken tkn = cancellationTokenSource.Token;
    
    private async Task myTask(CancellationToken tkn)
    {
    	Console.WriteLine("Hi now i'm inside the Task");	
    	var IsOut =  await Task.Run(()=> {
    		while(true)
    				{
    					Console.Write("*");
    					Thread.Sleep(500);
    				}
    		return true;
    		});
    	tkn.ThrowIfCancellationRequested();
    	Console.WriteLine("This code not execute");
    //Do other things
    }
    
    Console.WriteLine("Before to invoke the Taks");
    Task.Run(()=> myTask(tkn));
    Thread.Sleep(3000);
    cancellationTokenSource.Cancel();
    Console.WriteLine("");
    Console.WriteLine("The End ");
