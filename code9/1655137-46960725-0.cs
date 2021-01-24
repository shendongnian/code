    public interface IProcessableComponent
    {
        void Process(Vector3 position);
    }
    public abstract class ProcessableComponentBase : MonoBehaviour, IProcessableComponent
    {
        [SerializeField]
        private Vector3 holdedVector;
        public Vector3 HoldedVector { get { return holdedVector; } protected set { holdedVector = value; } }
        public virtual void Process(Vector3 newVector)
        {
            HoldedVector = newVector;
        }
    }
    public class ComponentA : ProcessableComponentBase
    {
    }
    public class ComponentB : ProcessableComponentBase
    {
    }
    public class TestComponentProcessing : MonoBehaviour
    {
        private void Awake()
        {
            var components = GetComponents<IProcessableComponent>();
            foreach(var entry in components)
            {
                entry.Process(Vector3.zero);
            }
        }
    }
