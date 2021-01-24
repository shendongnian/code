     public class ColliderBridge : MonoBehaviour
     {
         ColliderListener _listener;
         public void Initialize(ColliderListener l)
         {
             _listener l;
         }
         void OnCollisionEnter2D(Collision2D collision)
         {
             _listener.OnCollisionEnter2D(collision);
         }
         void OnTriggerEnter2D(Collider2D other)
         {
             _listener.OnTriggerEnter2D(other);
         }
     }
