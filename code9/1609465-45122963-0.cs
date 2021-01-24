    public class MyClass
    {
        private GameObject initiator;
        
        public MyClass(GameObject initiator)
        {
            this.initiator = initiator;
        }
    }
    public class MyInitiator : MonoBehaviour
    {
        void Start()
        {
            MyClass first = NewMyClass();
            MyClass second = NewMyClass();
            // ...
        }
        private MyClass NewMyClass()
        {
            return new MyClass(this);
        }
    }
