    public class DetectPlayer : MonoBehaviour
    {
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Platform")
            {
                Debug.Log("Touching Platform");
            }
        }
    
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "OnTop Detector")
            {
                Debug.Log("On Top of Platform");
            }
        }
    }
