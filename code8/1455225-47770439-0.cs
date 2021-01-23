    public class OpenWebsiteOnHeadsetRemove : MonoBehaviour
    {
    	#region Serialized
    	public OVRManager m_OVRManager;
    	#endregion
    
    	#region Variables
    	private bool m_UserPresent = true;
    	private bool m_HasOpenedURL = false;
    	#endregion
    
    	#region Lifecycle
    	private void Update () {
    	#if UNITY_ANDROID
    		bool isUserPresent = m_OVRManager.isUserPresent;
    
    		if( m_UserPresent != isUserPresent )
    		{
    			if( isUserPresent == false && m_HasOpenedURL == false && Application.isEditor == false )
    			{
    				m_HasOpenedURL = true;
    				Application.OpenURL("http://www.google.co.uk");
    			}
    		}
    
    		m_UserPresent = isUserPresent;
    	#endif
    	}
    	#endregion
    }
