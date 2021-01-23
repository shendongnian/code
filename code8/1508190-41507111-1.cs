    public class ServerTime : MonoBehaviour
    {
        private static ServerTime localInstance;
        public static ServerTime time { get { return localInstance; } }
    
    
        private void Awake()
        {
            if (localInstance != null && localInstance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                localInstance = this;
            }
        }
    
        public static void Get()
        {
            if (time == null)
            {
                Debug.Log("Script not attached to anything");
                GameObject obj = new GameObject("TimeHolder");
                localInstance = obj.AddComponent<ServerTime>();
                Debug.Log("Automatically Attached Script to a GameObject");
            }
            time.StartCoroutine(time.ServerRequest());
        }
    
        IEnumerator ServerRequest()
        {
            WWW www = new WWW("http://www.businesssecret.com/something/servertime.php");
    
            yield return www;
    
            Debug.Log(www.text);
        }
    }
