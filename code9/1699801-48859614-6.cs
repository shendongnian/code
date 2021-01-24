    public class WordDictionary: MonoBehaviour{
        public static Dictionary<string,bool> _wordDictionary = new Dictionary<string,bool> ();
        static WordDictionary() {
            _wordDictionary.Add ("Bad",true);
        }
    
        private void Start(){
        }
    }
