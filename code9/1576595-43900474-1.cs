    public class Something : MonoBehaviour,CMonoBehaviour
    {
        private int a;
        public int SomeHelperProperty1 {
            get {
                return a;
            }
    
            private set  {
                a = value;
            }
        }
        ...
    }
