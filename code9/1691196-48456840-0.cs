    public class BasePlayer : MonoBehaviour {
        [Header("Stats")]
        public int stat1 = 0;
        public int stat2 = 0;
    }
    public class MyPlayer : BasePlayer {
        public int stat3 = 0;
        public string duck = "quak";
    
        [Header("Stats2")]
        public string cow = "mooooo";
    }
