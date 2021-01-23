    using UnityEngine;
    using System.Collections;
    
    public class Touch : MonoBehaviour
    {
        public float doubleTapMaxDelay = 0.5f ;
        private float firstTapTime ;
    
        void OnCollisionEnter(Collision other)
        {
            Debug.Log ("Collision Event " + other.transform.name);
            string tipOfHand = other.transform.parent.name;
            if (tipOfHand == "index")
            {
                // Detect if second tap occured within the given max delay
                if( (Time.time - firstTapTime) < doubleTapMaxDelay )
                {
                    // Double tap
                    firstTapTime = 0 ;
                    Application.LoadLevel(1);
                }
                // Else, indicate the time the first tap has been made
                else
                {
                    // Single tap
                    firstTapTime = Time.time ;
                }
            }
          }
        }
    }
