   	public class Test : MonoBehaviour
	{
	    private static bool _cloned = false;
	    public static T Clone<T>(T source) where T : class 
	    {
	        if (typeof(T) == typeof(GameObject))
	        {
	            GameObject clone = Instantiate(source as GameObject);
	            return clone as T;
	        }
	        else if (typeof(T) == typeof(PlainType))
	        {
	            PlainType p = new PlainType();
	            // clone code
	            return p as T;
	        }
	        return null;
	    }
	    public class PlainType
	    {
	        private static int _counter = 0;
	        public int Count = ++_counter;
	        public string Text = "Counter = " + _counter;
	    }
	    public PlainType MyPlainType = new PlainType();
		void Update ()
		{
		    if (!_cloned)
		    {
		        _cloned = true;
		        Clone(gameObject);
		        PlainType plainClone = Clone(MyPlainType);
	            Debug.Log("Org = " + MyPlainType.Count + " Clone = " + plainClone.Count);
		    }
		}
	}
