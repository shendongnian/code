    PlayerBase : MonoBehaviour
    {
        //Some props
        public Color Color {get; set;}
    
        protected virtual void Start()  // make it virtual so childs can override
        {
            Color = Color.Red;
        }
    }   
    
    PlayerLife : PlayerBase
    {
        override void Start()
        {
            base.Start();    // call first base class implementation
            Cube.Color = base.Color;
        }
    }   
    
    
    PlayerController : PlayerBase
    {
        override void Start()
        {
            base.Start();    // call first base class implementation
            Foo.Color = base.Color;
        }
    }
