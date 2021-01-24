    [RequireComponent(typeof(Rigidbody2D))] // Added this code
    public class Ball : MonoBehaviour {
      private Rigidbody2D _rigiBody; 
      public Rigidbody2D RigidBody { //And this property
       get {
         if (_rigiBody  == null)
           _rigiBody = GetComponent<Rigidbody2D>();
            return _rigiBody;
          }
       }
