    [System.Serializable]
    public class BeforeTimeChangedData
    {
    	public bool canceled;
    	public float oldValue;
    	public float newValue;
    }
    
    
    [System.Serializable]
    public class BeforeTimeChangedEvent : UnityEvent<BeforeTimeChangedData>
    {
    }
    
    //Attach this to a game object that gets loaded in your pre-load scene with the tag "Singletons"
    public class TimeController : MonoBehaviour 
    {   
    	void Awake()
    	{
    		DontDestroyOnLoad(gameObject);
    
    		if(BeforeTimeChanged == null)
    			BeforeTimeChanged = new BeforeTimeChangedEvent();
    	}
    
    	public BeforeTimeChangedEvent BeforeTimeChanged;
    
    	public bool ChangeTimeScale(float newValue)
    	{
    		var args = new BeforeTimeChangedData();
    		args.oldValue = Time.timeScale;
    		args.newValue = Time.timeScale;
    		BeforeTimeChanged.Invoke(args);
    		if(!args.canceled)
    		{
    			Time.timeScale = newValue;
    		}
    		return args.canceled;
    	}
    }
