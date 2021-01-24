    public class TimeTest : MonoBehaviour
    {
        public bool UseUnityFuntion;
    
        private string msg;
    
    	void Update ()
    	{
    	    var stopwatch = Stopwatch.StartNew();
    	    msg = UseUnityFuntion 
                ? Time.time.ToString() 
                : DateTime.UtcNow.Millisecond.ToString();
            stopwatch.Stop();
            UnityEngine.Debug.Log(stopwatch.ElapsedTicks);
    	}
    
        void OnGUI()
        {
            if (msg != null) GUILayout.Label(msg);
        }
    }
