    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    
    public class ssj : MonoBehaviour {
        public Text text;
        IEnumerator ShowMessageCoroutine(string message, float timeToShow = 10)
        {
            //Wait for 5 seconds
            yield return new WaitForSecondsRealtime(5f);
    
            // Show the text
            text.enabled = true;
            text.text = message;
    
            //Wait for 8 seconds
            yield return new WaitForSecondsRealtime(8f);
    
            // Hide the text
            text.enabled = false;
            text.text = "";
        }
    }
