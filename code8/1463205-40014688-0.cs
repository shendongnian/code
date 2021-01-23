    public abstract class ObjectPooling<T>: MonoBehaviour where T : UnityEngine.Component 
    {
    
        public static float start = 30;
        public static bool extendable = true;
    
        public List<T> objects = new List<T>();
    
        public abstract T getNext();
        public abstract void Add(T obj);
    
        static T m_instance;
        public static T instance
        {
            get
            {
                return m_instance ?? (m_instance = CreateInstance());
            }
        }
    
        protected static T CreateInstance()
        {
    
            GameObject g = new GameObject("ObjectPooling");
            var c = g.AddComponent<T>;
            return c;
        }
    }
