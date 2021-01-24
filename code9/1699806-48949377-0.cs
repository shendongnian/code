    //Please note I have edited uni9mportant code out
    
    //Event Listener
    inputField.onEndEdit.AddListener (delegate {
                VerifyWords();
    });
    
    //Clss that handles the dictionary
    public abstract class WordDictionary: MonoBehaviour{
        public static Dictionary<string,bool> _wordDictionary = new Dictionary<string,bool> ();
    
        private void Start(){
            _wordDictionary.Add ("Bad",true);
        }
    }
    
    //Function that handles the word verification
    private void VerifyWords(){
            if (openChat == false) { //If we done have open chat
                bool hasBadWords = false; //Reset boolean
                string[] stringSplit = inputField.text.Split (' '); //Split text string
                int i=0;
                for (i = 0; i < stringSplit.Length; i++) { // Go through each word in the string array
                    if (WordDictionary._wordDictionary.ContainsKey (stringSplit[i])) { //If the word is in the dictionary
                         inputField.textComponent.color = Color.red; //Then the text should be red
                    }
                }
    
                if (i == stringSplit.Length) { //If a bad word was found
                 inputField.textComponent.color = Color.green; //The text should be green  
                }
            }
        }
