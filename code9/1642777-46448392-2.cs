    public class TopComp: MonoBehaviour
    {
        private SubComponent sub = null;
        void Start(){
            this.sub = new SubComponent();
        }
        void OnEnable(){ this.sub.OnEnable();} 
        void Update(){ this.Update();}
    }
    public class SubComponent{
        public void OnEnable(){}
        public void Update(){}
    }
