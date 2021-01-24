     public class GameControl : MonoBehaviour
     {
       public int coins;
       public static GameControl gamecontrol;
       void Awake()
      {
        if (gamecontrol == null)
        {
            DontDestroyOnLoad(gameObject);
            gamecontrol = this;
            
        }
          else if (gamecontrol != this)
         {
            Destroy(gameObject);
         }
       }
    }
