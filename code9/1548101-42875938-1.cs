    public class StartGame : MonoBehaviour {
    
        public genDicTable GEN;    
    
        private void Start()
        {
            GEN = GameObject.Find("your object's name").GetComponent<genDicTable>();`
            Debug.Log(GEN.masterCount); // <-- This yields NULL.
        }
    }
