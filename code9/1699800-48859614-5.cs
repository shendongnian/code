    public class WordDictionary: MonoBehaviour{
        public static Dictionary<string,bool> _wordDictionary = new Dictionary<string,bool> ();
    
        private void Start(){
            _wordDictionary.Add ("Bad",true);
        }
    }
