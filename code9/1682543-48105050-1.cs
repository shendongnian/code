        public class SomeMono : MonoBehaviour
        {
            [SerializeField]
            private Data _data;
            void Awake()
            {
                Debug.Log("Data.SomeString is " + _data.SomeString);
            }
        }
