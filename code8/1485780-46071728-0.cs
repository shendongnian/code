        public class ExampleService : IMicroService
        {
	        public void Start()
	        {
		        Console.WriteLine("I started");
	        }
	    
	        public void Stop()
	        {
		        Console.WriteLine("I stopped");
	        }
        }  
