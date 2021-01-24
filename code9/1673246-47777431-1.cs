    public class BLEBridge : MonoBehaviour {
    
    	public delegate void UnityCallbackDelegate(/*IntPtr objectName, IntPtr methodName, IntPtr parameter*/);
    	[DllImport ("__Internal")]
    	public static extern void ConnectCallback(UnityCallbackDelegate callbackMethod);
    	[MonoPInvokeCallback(typeof(UnityCallbackDelegate))]
    	private static void ManagedTest()
    	{
    		Debug.Log("IT WORKS!!!!");
    	}
    }
