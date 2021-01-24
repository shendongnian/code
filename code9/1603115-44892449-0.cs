    // ignoring the using statements...
    public class texttype : MonoBehaviour {
        public float letterPause = 0.2f;
        //public AudioClip[] typeSound1;
        //public int next;
        string message;
        public GameObject textB;
        public Text text;
        public TextAsset textf;
        public string[] lines;
        public int currentLine;
        public int endline;
        public bool isPrinting;
        void Start () {
            if (text == null) {
                text = GetComponent<Text> ();
            }
            
            // it's not clear where you store the full message, but I'm assuming inside textf
            // if you have it stored in message or text.text, then you can initialize it here
    
            if (textf != null) {
                lines = (textf.text.Split('\n'));
            }
    
            if (endline == 0) {
                endline = lines.Length - 1;
            }    
        }
    
        IEnumerator TypeText () {    
            // get current line of text
            string current = lines[currentLine];
            foreach (char letter in current.ToCharArray()) {
                text.text += letter;
                yield return 0; // not sure this line is necessary
                yield return new WaitForSeconds (letterPause);    
            }
            // unlock and wait for next keypress
            isPrinting = false;
        }
    
    
    
        void Update () {
            // if we're already printing a line, we can short-circuit
            if (isPrinting) return;
    
            if (Input.GetKeyDown (KeyCode.Space)) {
                // move line index
                currentLine += 1;
                if (currentLine > endline) {    
                    textB.SetActive(false);
                    return;
                }
                // start printing
                PrintNext();
            }
    
        }
        void PrintNext() {
            // redundant check, but better safe than sorry
            if (isPrinting) return;
            // lock while printing
            isPrinting = true;
            StartCoroutine(TypeText ());      
        }
    
    }
