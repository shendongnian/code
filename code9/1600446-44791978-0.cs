        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        
        public class TimeBubble : MonoBehaviour {
        
            [Range(0,1)]
            public float speedReductionFactor = .5f;
        
            List <GameObject> objectsInside;
        
            Rigidbody2D rb;
        
            void Start ()
            {
                objectsInside = new List<GameObject>();
            }
        
            void OnTriggerEnter2D(Collider2D other) {
                rb = other.gameObject.GetComponent<Rigidbody2D>();
                if (rb == null)
                    return;
                rb.velocity *= speedReductionFactor;
                objectsInside.Add(other.gameObject);
            }
        
            void OnTriggerExit2D (Collider2D other){
                rb = other.gameObject.GetComponent<Rigidbody2D>();
                if (rb != null && objectsInside.Contains(other.gameObject)) {
                    rb.velocity *= (1 / speedReductionFactor);
                    objectsInside.Remove(other.gameObject);
                }
            }
            
        }
