    public class ServiceTest : MonoBehaviour
    {
        private void Start()
        {
            // no need to Create services
            // They will be created when Provide is first called on them
            // Though if you want them up and running at Start, call Provide
            // on each here.
        }
    
        private void Example()
        {
            // Get a service
            ServiceManager services = FindObjectOfType<ServiceManager>();
            MapService map = services.Provide<MapService>();
            // do whatever you want with map
        }
    }
