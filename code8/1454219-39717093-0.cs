    public class ClassB : MonoBehaviour
    {
        [SerializeField] private MonoA monoA = null;
        public void Init(){
            this.monoA = this.gameObject.GetComponent<MonoA>();
        }
        public void GetMonoAValue(){
            if(this.monoA == null){  this.monoA = this.gameObject.GetComponent<MonoA>(); }
            return this.monoA.Value;
        }
    }
    
    public class ClassA:MonoBehaviour
    {
         private void Start(){
             ClassB classB = FindObjectOfType<ClassB>();
             classB.Init();
             Value v = classB.GetMonoAValue(); 
         }
    }
