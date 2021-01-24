    public class Detector : MonoBehaviour {
        void OnTriggerEnter(Collider other) {
            if(other.tag == "enemy"){
               //Do what you need
            }       
        }
    }
