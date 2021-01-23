    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    
    
    public class ChangeText : MonoBehaviour
    {
        // Drag & Drop the desired Text component here
        public Text TextToChange ;
        // Write the new content of the Text component
        public string NewText ;
        private void Awake()
        {
            TextToChange.text = NewText;
        }
    }
