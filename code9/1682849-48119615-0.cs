      [RequireComponent(typeof(BoxCollider))]
      public class FPSControllerCollission : MonoBehaviour {
        public bool IsTriggered;
        
        private void OnTriggerEnter(Collider other) {
          this.IsTriggered = true;
        }
    
        private void OnTriggerExit(Collider other) {
          //Maybe check the tag/type of the other object here
          this.IsTriggered = false;
        }
      }
    
