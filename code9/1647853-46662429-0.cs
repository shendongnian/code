    public class PhysicsObject : MonoBehaviour
    {
        protected virtual void Update()
        {
            ComputeVelocity();
            Debug.LogFormat("PhysicsObject Update");
        }
        protected virtual void ComputeVelocity()
        {
            Debug.LogFormat("PhysicsObject ComputeVelocity");
        }
    }
    public class PlayerPlatformerController : PhysicsObject
    {
        protected override void Update()
        {
            base.Update();
            Debug.LogFormat("PlayerPlatformerController Update");
        }
        protected override void ComputeVelocity()
        {
            base.ComputeVelocity();
            Debug.LogFormat("PlayerPlatformerController ComputeVelocity");
        }
    }
