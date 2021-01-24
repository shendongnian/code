    public class Program // Consider this your home form
    {
    	public void Main()
    	{
    		var serviceController = new ServiceController();
    		serviceController.ServiceStateChange += ServiceController_ServiceStateChanged;
    		serviceController.StartServices();
    	}
    	
    	private void ServiceController_ServiceStateChanged(object sender, ServiceControllerEventArgs e)
    	{
    		// Add to listbox or do whatever you want. I am just printing.
    		Console.WriteLine(e.Message);
    	}
    }
    
    public class ServiceController
    {
    	public event EventHandler<ServiceControllerEventArgs> ServiceStateChange;
    	
    	public void StartServices()
    	{
    		Service[] services = new Service[] // Sample services data
    		{ 
    			new Service { Name = "MSMQ", Status = "Stopped" },
    			new Service { Name = "W3SVC", Status = "Running" }
    		};
    		
    		string message = null;
    		
    		foreach(Service s in services) 
    		{
    			if(s.Status == "Stopped") 
    			{
    				s.Start();
    				// Assuming it starts almost immediately. If not, you could follow same pattern for 
    				// Service class where an event will be raised once service is "actually" started.
    				if(s.Status == "Running") {
    					message = string.Format("Service {0} is {1}", s.Name, s.Status);
    				}
    			}
    			else if(s.Status == "Running") {
    				message = string.Format("Service {0} is already {1}", s.Name, s.Status);
    			}
    			
    			// Now tell subscriber (home form) about this.
    			OnServiceStateChange(message);
    		}
    	}
    	
    	private void OnServiceStateChange(string message)
    	{
    		var serviceStateChangeHandler = ServiceStateChange;
    		if(serviceStateChangeHandler != null)
    		{
    			serviceStateChangeHandler(this, new ServiceControllerEventArgs { Message = message });
    		}
    	}
    }
    
    // You could have custome delegate type for event to return string message.
    // But IMO this is much cleaner, and as per MSFT guidelines.
    public class ServiceControllerEventArgs : EventArgs
    {
    	// You can also return Service instance
    	// Just including Message for now 
    	public string Message { get; set; }
    }
    
    // for demo purpose, represents individual service.
    public class Service
    {
    	public string Name { get; set; }
    	public string Status { get; set; }
    	
    	public void Start() {
    		Status = "Running";
    	}
    }
