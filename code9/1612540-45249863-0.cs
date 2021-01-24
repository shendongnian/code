    using System.Collections;
    using UnityEngine;
    
    public class PreCountdownTimer : MonoBehaviour {
    
        private IEnumerator counter;
    
       void Update()
        {
            if (!GameManager.Instance.UserActive && !GameManager.Instance.PreCountdownActive)
                StartPreCountTimer(GameManager.Instance.PreCountdownLength);
            else if (GameManager.Instance.UserActive && GameManager.Instance.PreCountdownActive)
                StopPreCountTimer();
        }
    
        void StartPreCountTimer(float length)
        {
            GameManager.Instance.PreCountdownActive = true;
            counter = RunTimer(length);
            StartCoroutine(counter);   
        }
    
        void StopPreCountTimer()
        {
            GameManager.Instance.PreCountdownActive = false;
            StopCoroutine(counter);
        }
    
        IEnumerator RunTimer(float seconds)
        {
            float s = seconds;
            while (s > 0)
            {
                yield return new WaitForSeconds(GameManager.Instance.PreCountdownInterval);
                s -= GameManager.Instance.PreCountdownInterval;
                Debug.Log("PreCount: " + s);
            }
    
            if (s == 0)
            {
                GameManager.Instance.PreCountdownActive = false;
            }
        }
    }
