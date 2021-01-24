    public class Zombie : MonoBehaviour
    {
        static Player player;
        void Start()
        {
            if(player == null)
            {
                player = Player.Instance;
            }
        }
        // Rest of your class content
    }
