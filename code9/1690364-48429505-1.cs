    public class ColliderListener : MonoBehaviour
     {
         void Awake()
         {
             // Check if Colider is in another GameObject
             Collider2D collider = GetComponentInChildren<Collider2D>();
             if (collider.gameObject != gameObject)
             {
                 ColliderBridge cb = collider.gameObject.AddComponent<ColliderBridge>();
                 cb.Initialize(this);
             }
         }
         public void OnCollisionEnter2D(Collision2D collision)
         {
             // Do your stuff here
         }
         public void OnTriggerEnter2D(Collider2D other)
         {
             // Do your stuff here
         }
     }
