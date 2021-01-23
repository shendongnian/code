    public class PlayerBase : MonoBehaviour
    {
        public Color Color;
    
        public Color matColor
        {
            get
            {
                Color = gameObject.GetComponent<Renderer>().material.GetColor("_Color");
                return Color;
            }
            set
            {
                Color = value;
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color);
            }
        }
    
    
        // Use this for initialization
        protected virtual void Start()
        {
            matColor = Color;
        }
    
        // Update is called once per frame
        protected virtual void Update()
        {
    
        }
    }
