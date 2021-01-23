    //This would be attached to said gameobject that displays the amount.
    public class Amount : MonoBehaviour
    {
    	public static Amount instance = null;
    
        void Awake()
        {
        		if (instance == null)
        			instance = this;
        
        		if (instance != this)
        			Destroy(gameObject);
        
        		DontDestroyOnLoad(gameObject);
        }
    }
    //And here you would destroy said gameobject that displays the amount.
    public class DestroyThatAmount
    {
        void DestroyIt()
        {
            Destroy(Amount.instance.gameobject);
        }
    }
