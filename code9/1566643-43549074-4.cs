    public class ServiceTest : MonoBehaviour
    {
        private void Start()
        {
            // no need to Create services
        }
    
        private void Example()
        {
            // Get a service
            ServiceManager services = FindObjectOfType<ServiceManager>();
            MapService map = services.Provide<MapService>();
            // do whatever you want with map
        }
    }
