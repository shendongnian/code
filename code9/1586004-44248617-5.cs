    public class TimeChangeLimiter : MonoBehaviour 
    {
    	private float lastTimeChange = 0;
    	private TimeController _timeController;
    	public Text TimeChanged;
    
    	[Range(0, float.MaxValue)]
    	public float Cooldown;
    
    	void Start()
    	{
    		var singletons = GameObject.FindWithTag("Singletons");
    		_timeController = singletons.GetComponent<TimeController>();
    		if(_timeController == null)
    			throw new System.ArgumentNullException("Could not find a TimeController on the Singletons object");
    		_timeController.BeforeTimeChanged.AddListener(OnBeforeTimeChanged);
    	}
    
    	void OnDestroy()
    	{
    		_timeController.BeforeTimeChanged.RemoveListener(OnBeforeTimeChanged);
    	}
    
    
    	void OnBeforeTimeChanged(BeforeTimeChangedData args)
    	{
    		if(Time.time - lastTimeChange < Cooldown)
    		{
    			args.canceled = true;
    			return;
    		}
    		lastTimeChange = Time.time;
    	}
    }
