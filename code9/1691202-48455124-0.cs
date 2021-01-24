    public abstract class AssetMetadata : MonoBehaviour
    {
        public string name;
    }
    
    public class LegMetadata : AssetMetadata
    {
        public float thickness;
    }
    
    public abstract class Controller<TMetadata> : MonoBehaviour where TMetadata : AssetMetadata
    {
        public TMetadata metadata;
    }
    
    public class LegController : Controller<LegMetadata>
    {
        private void Start()
        {
            metadata = GetComponent<LegMetadata>();
            Debug.Log(metadata.thickness);
        }
    }
