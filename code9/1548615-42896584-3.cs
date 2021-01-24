    using UnityEngine;
    using System.Collections;
    
    public class WaitForSecondsExample : MonoBehaviour {
        
        void Start() {
            StartCoroutine(CountDown());
        }
        
        IEnumerator CountDown() {
            countdown.text = "3";
            yield return StartCoroutine(CoroutineUtilities.WaitForRealTime(1));
            countdown.text = "2";
            yield return StartCoroutine(CoroutineUtilities.WaitForRealTime(1));
            countdown.text = "1";
            yield return StartCoroutine(CoroutineUtilities.WaitForRealTime(1));
            //time up, now resume the app
        }
    }
