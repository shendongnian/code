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
		public resultObject Result {get; set;}
		public AutoResetEvent Event {get; private set;}
		
		public PromiseResult(AutoResetEvent are){
			Event = are;
		}		
	}
	
	public class Example{
		
		public void Test(){
			
			var promise = makeMyRequest();
			
			//do some work
			
			//Now I need the result:
			promise.Event.WaitOne();
			Console.WriteLine(promise.Result);
		}
	}
