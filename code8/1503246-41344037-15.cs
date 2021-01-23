    public class PlayerLife : PlayerBase
    {
        public PlayerBase pBase;
    
        void Awake()
        {
            pBase = this;
        }
    
        // Use this for initialization
        protected override void Start()
        {
            matColor = Color;
        }
    
        // Update is called once per frame
        protected override void Update()
        {
    
        }
    }
