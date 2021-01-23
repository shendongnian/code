    using UnityEngine;
    using System.Collections;
    public class WaitForSecondsExample : MonoBehaviour {
        void Start() {
            StartCoroutine(Example());
        }
        
        IEnumerator Example() {
            Debug.Log(Time.time); // time before wait
            yield return new WaitForSeconds(5);
            Debug.Log(Time.time); // time after wait
        }
    }
