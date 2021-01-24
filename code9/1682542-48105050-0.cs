        [CreateAssetMenu("my_data.asset", "My Data")]
        public class Data : ScriptableObject
        {
            [SerializeField]
            private int _n;
    
            [SerializeField]
            private string _someString;
            public int N { get { return _n; }}
            public string SomeString { get { return _someString; }}
        }
