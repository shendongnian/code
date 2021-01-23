    public class TextFieldBehaviour : MonoBehaviour, ISelectHandler
    {
        private InputField inputField;
        private bool isCaretPositionReset = false;
    
        void Start()
        {
            inputField = gameObject.GetComponent<InputField>();
        }
    
        public void OnSelect(BaseEventData eventData)
        {
            StartCoroutine(disableHighlight());
        }
    
        IEnumerator disableHighlight()
        {
            Debug.Log("Selected!");
    
            //Get original selection color
            Color originalTextColor = inputField.selectionColor;
            //Remove alpha
            originalTextColor.a = 0f;
    
            //Apply new selection color without alpha
            inputField.selectionColor = originalTextColor;
    
            //Wait one Frame(MUST DO THIS!)
            yield return null;
    
            //Change the caret pos to the end of the text
            inputField.caretPosition = inputField.text.Length;
            //inputField.selectionFocusPosition = inputField.text.Length;
    
            //Return alpha
            originalTextColor.a = 1f;
    
            //Apply new selection color with alpha
            inputField.selectionColor = originalTextColor;
        }
    }
