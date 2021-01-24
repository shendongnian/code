    public class ColliderListener : MonoBehaviour
     {
         void Awake()
         {
             // Check if Colider is in another GameObject
             Collider collider = GetComponentInChildren<Collider>();
             if (collider.gameObject != gameObject)
             {
                 ColliderBridge cb = collider.gameObject.AddComponent<ColliderBridge>();
                 cb.Initialize(this);
             }
         }
         public void OnCollisionEnter(Collision collision)
         {
             // Do your stuff here
         }
         public void OnTriggerEnter(Collider other)
         {
             // Do your stuff here
         }
     }
