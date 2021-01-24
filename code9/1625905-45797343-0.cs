    public class SceneLoaderSingleton : MonoBehaviour
    {
        //Static instance of SceneLoaderSingleton which allows it to be accessed by any other script.
        public static SceneLoaderGameObject instance = null;    
      
        //Awake is always called before any Start functions
        void Awake()
        {
            //Check if instance already exists
            if (instance == null)
                
                //if not, set instance to this
                instance = this;
            
            //If instance already exists and it's not this:
            else if (instance != this)
                
                //Then destroy this. This enforces singleton pattern, meaning there can only ever be one instance of a SceneLoaderSingleton.
                Destroy(gameObject);    
            
            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);            
        }
        
       
