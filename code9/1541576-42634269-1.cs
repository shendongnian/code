    public class MapDetect : MonoBehaviour {
        
        public  Text Text;
        
        void Start()
        {
            Text.text = "Map out";
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
                Text.text = "Map on";
        }
        
        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
                Text.text = "Map out";
        }
    }
