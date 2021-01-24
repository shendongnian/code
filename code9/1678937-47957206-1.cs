    public class FollowJoint : CustomConfigurableJoint
    {
        protected override void Awake()
        {
            base.Awake();
        }
    
        void Start()
        {
            configurableJoint.xMotion = ConfigurableJointMotion.Limited;
        }
    }
