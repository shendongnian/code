    public class VIVEController : MonoBehaviour 
    {
    	public SteamVR_TrackedObject trackedObj;
    	private SteamVR_Controller.Device controller;
    
    	void Start () 
    	{
    		controller = SteamVR_Controller.Input ((int)trackedObj.index);
    	}
    	
    	void Update ()
    	{
    		if (controller.GetPressDown (Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger)) 
    		{
    			OnTriggerPressed ();
    		}
    
            if (controller.GetPressDown (Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad)) 
            {
                OnTouchpadPressed ();
            }
    	}
    
    	private void OnTriggerPressed()
    	{
            Debug.Log("OnTriggerPresse");
        }
    
        private void OnTouchpadPressed()
        {
            Debug.Log("OnTouchpadPressed");
        }
    }
