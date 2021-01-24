    public class CustomConfigurableJoint : MonoBehaviour
    {
        protected ConfigurableJoint configurableJoint;
    
        protected virtual void Awake()
        {
            //Create it
            configurableJoint = gameObject.AddComponent<ConfigurableJoint>();
           
            //Modify it below 
            configurableJoint.xMotion = ConfigurableJointMotion.Limited;
            configurableJoint.yMotion = ConfigurableJointMotion.Limited;
            configurableJoint.zMotion = ConfigurableJointMotion.Limited;
            configurableJoint.angularXMotion = ConfigurableJointMotion.Locked;
            configurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
            configurableJoint.angularZMotion = ConfigurableJointMotion.Locked;
        }
    }
