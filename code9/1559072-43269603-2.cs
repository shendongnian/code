    public class CloneObjects : MonoBehaviour
    {
        public List<GameObject> cloneList = new List<GameObject>();
    }
    public class AnotherScript : MonoBehaviour
    {
        void Start()
        {
            var cloneObjects = obj_with_CloneObjects.GetComponent<CloneObjects>();
            //cloneObjects.cloneList 
        }
    }
