    public class KeyCodeFinder : MonoBehaviour
    {
        public Text text;
    
        Array allKeyCodes;
    
        void Start()
        {
            allKeyCodes = System.Enum.GetValues(typeof(KeyCode));
        }
    
        void Update()
        {
            foreach (KeyCode tempKey in allKeyCodes)
            {
                if (Input.GetKeyDown(tempKey))
                {
                    text.text = "Pressed: KeyCode." + tempKey;
                    Debug.Log("Pressed: KeyCode." + tempKey);
                }
            }
        }
    }
