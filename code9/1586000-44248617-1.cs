    public class TimeSlower : MonoBehaviour 
    {
    	private TimeController _timeController;
    	public Text TimeChanged;
    
    	void Start()
    	{
    		var singletons = GameObject.FindWithTag("Singletons");
    		_timeController = singletons.GetComponent<TimeController>();
    		if(_timeController == null)
    			throw new System.ArgumentNullException("Could not find a TimeController on the Singletons object");
    	}
    
    	void Update()
    	{
    		if(Input.GetButton("SlowTime"))
    		{
    			var changed = _timeController.ChangeTimeScale(0.5f);
    			if(changed)
    			{
    				TimeChanged.text = "Time Changed!";
    			}
    		}
    	}
    }
 
