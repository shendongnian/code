    public class CustomConfigurableJoint : MonoBehaviour
    {
        protected ConfigurableJoint configurableJoint;
    
        protected virtual void Awake()
        {
            configurableJoint = GetComponent<ConfigurableJoint>();
        }
    }
