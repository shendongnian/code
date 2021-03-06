    public class GameBase : MonoBehaviour
    { 
        public List<PlayerBase> Players { get; set; } 
    
        void Start()
        {
            var playerObj1 = Instantiate(Resources.Load("Prefabs/Players/PlayerPrefab")) as GameObject;
            PlayerBase player1 = playerObj1.GetComponent<PlayerBase>();
            player1.SetColor(0);
            player1.Name = "Naografix Red"; 
    
            var playerObj2 = Instantiate(Resources.Load("Prefabs/Players/PlayerPrefab")) as GameObject;
            PlayerBase player2 = playerObj2.GetComponent<PlayerBase>();
            player2.SetColor(1);
            player2.Name = "Foo Blue"; 
    
            Players = new List<PlayerBase>{
                player1,
                player2
            }
        }
    } 
