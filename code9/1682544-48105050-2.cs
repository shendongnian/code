        public class SomeMono2 : MonoBehaviour
        {
            [SerializeField]
            private TextAsset _text;
            void Awake()
            {
                // Assumes that the data is just a plain string sequence.
                // However, it could be any text data you like.
                Debug.Log(_text.text);
                // Or you can serialize your data as bytes
                // byte[] byteData = _text.bytes
            }
        }
