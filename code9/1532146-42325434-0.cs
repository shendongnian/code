     public class ScoreManager: MonoBehaviour
     {
         private static ScoreManager_instance ;
     
         void Awake()
         {
             //we will make an instance if we don't have one yet
             if(!_instance)
                 _instance = this ;
             //if we have an instance we don't need this one so we Destroy it
             else
                 Destroy(this.gameObject) ;
     
              //we can keep this object between the scense with DontDestroyOnLoad
             DontDestroyOnLoad(this.gameObject) ;
         }
     }
