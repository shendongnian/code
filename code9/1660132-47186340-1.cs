    public class MonoSingleton
    {
    	public static TransporterSystem instance
    	{
    		get
    		{
    			if (m_Instance == null)
    				m_Instance = Object.FindObjectOfType<TransporterSystem>();
    
    			if (m_Instance == null)
    				Debug.LogError("Unable to find TransporterSystem instance in scene.");
    
    			return m_Instance;
    		}
    	}
    
    	private static TransporterSystem m_Instance;
    }
