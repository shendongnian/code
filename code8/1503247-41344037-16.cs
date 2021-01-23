    public class Game : MonoBehaviour
    {
        private List<PlayerLife> _players;
        public GameObject Player;
    
        void Start()
        {
            _players = new List<PlayerLife>();
    
            GameObject obj = Instantiate(Player);
            PlayerLife playerLife = obj.GetComponent<PlayerLife>();
            playerLife.matColor = Color.blue;
            _players.Add(playerLife);
    
            GameObject obj2 = Instantiate(Player) as GameObject;
            PlayerLife playerLife2 = obj2.GetComponent<PlayerLife>();
            playerLife2.Color = Color.red;
            _players.Add(playerLife2);
        }
    
        void Update()
        {
    
        }
    }
