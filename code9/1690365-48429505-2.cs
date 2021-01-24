     public class ColliderBridge : MonoBehaviour
     {
         ColliderListener _listener;
         public void Initialize(ColliderListener l)
         {
             _listener l;
         }
         void OnCollisionEnter(Collision collision)
         {
             _listener.OnCollisionEnter(collision);
         }
         void OnTriggerEnter(Collider other)
         {
             _listener.OnTriggerEnter(other);
         }
     }
