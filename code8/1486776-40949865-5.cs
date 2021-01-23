    public class RageController : BufferBase
    {
    	public static RageController instance;
    
    	public static bool IsActive { get { return instance._isBufferActive; } }
    
    	#region Static Methods
    	internal static void AddRage(float value)
    	{
    		instance.StartOrExtendBuffer(value);
    	}
    
    	internal static void Reset()
    	{
    		instance.ResetBuffer();
    	}
    	#endregion
    
    	#region Overriden Methods
    	protected override void StartOrExtendBuffer(float value)
    	{
    		base.StartOrExtendBuffer(value);
    
    		//----
    		//add speed etc..
    		//----
    	}
    
    	protected override void EndBuffer()
    	{
    		base.EndBuffer();
    
    		//----
    		//remove speed etc..
    		//----
    	}
     	#endregion   
    	#region Unity Methods
    	void Awake()
    	{
    		instance = this;
    	}
    	void FixedUpdate()
    	{
    		FixedUpdateBuffer();
    
    		if (_isBufferActive)
    		{
    			//----
    			//anything that changes by time
    			//----
    		}
    	}
    	#endregion
    }
