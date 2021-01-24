    public class ControllerSettings
    {
    	public string Setting1 { get; set; }
    
    	public int Setting2 { get; set; }
    
    	// ...
    }
    
    public class Controller
    {
    	private readonly ControllerSettings _settings;
    
    	public Controller(IOptions<ControllerSettings> options)
    	{
    		_settings = options.Value;
    	}
    }
