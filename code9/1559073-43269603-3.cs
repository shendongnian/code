    public class CloneObjects : MonoBehaviour
    {
        public List<GameObject> cloneList = new List<GameObject>();
        void Clone()
        {
        }
        void Start()
        {
            Clone();
            obj_with_AnotherScript.GetComponent<AnotherScript>.cloneList = cloneList;
        }
    }
    public class AnotherScript : MonoBehaviour
    {
        public List<GameObject> cloneList = new List<GameObject>();
        void Start()
        {
            //this.cloneList 
        }
    }
