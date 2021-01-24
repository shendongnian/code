    private async resultObject makeMyRequest()
    {
	    requestObject request = new requestObject();
				
		var returnValue = new PromiseResult(new AutoResetEvent(false));			
	
	    MakeRequest(request, 
			(result) =>  { 
				returnValue.Result = result; 
				returnValue.Event.Set(); 
			},
			(error) => { 
				returnValue.Event.Set();
		    });
				
				
		return returnValue;
	}
	
	
	public class PromiseResult {
		public resultObject Result {get;set;}
		public AutoResetEvent Event {get;}
		
		public PromiseResult(AutoResetEvent are){
			Event = are;
		}		
	}
	
	public class Example{
		
		public void Test(){
			
			var promise = makeMyRequest();
			
			while(true){
				
				if (promise.Event.WaitOne(0)){
					Console.WriteLine(promise.Result);
					return;
				}
				else
				{
					Console.WriteLine("Not ready yet ..., but the thread is free to do some other stuff");
					System.Threading.Thread.CurrentThread.Sleep(500);
				}
			}			
		}
	}
