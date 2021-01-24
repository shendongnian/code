    using UnityEngine;
    using System.Collections;
    
    public class Bullet : MonoBehaviour {
        
        void OnCollisionEnter(Collision collision)
        {
            var hit = collision.gameObject;
            
            /* Code below is from the original example
            var health = hit.GetComponent<Health>();
            if (health  != null)
            {
                health.TakeDamage(10);
            }*/
            var bubble = hit.GetComponent<BubbleBehavior>();
            if (bubble != null)
            {
                bubble.Popped(); // Implement a Popped function doing the magic
            }
    
            Destroy(gameObject);
        }
    }
