    public class MyComponent : MonoBehaviour
    {
        // Declare your serializable data
        [System.Serializable]
        public class Data {
            public int a;
            public float b;
            public float c;
            public int d;
            public bool e;
        }
    
        // Create list of your class type
        public List<Data> list = new List<Data>();
        ...
    
    }
