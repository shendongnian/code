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
    
    //Here would be what's needed to set the amount's parent.
    public class SetThatAmountsParentToThisGameObject : MonoBehaviour
    {
        void SetAmountParent()
        {
            Amount.instance.setParent(transform);
        }
    }
    //And here you would destroy said gameobject that displays the amount.
    public class DestroyThatAmount : MonoBehaviour
    {
        void DestroyIt()
        {
            Destroy(Amount.instance.gameobject);
        }
    }
