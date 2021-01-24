     public class enemy : MonoBehaviour {
        public Node nodeScript;
    
        // Use this for initialization
        void Start () {
            nodeScript = GameObject.Find("otherGameObjectName").GetComponent<Node>(); // Here bind your local Node reference to the actual instance
        }
    
        // Update is called once per frame
        void Update () {
    
            test();
            Debug.Log(nodeScript.FinalPath.Count);
        }
    
        public void test()
        {
            nodeScript.FinalPath.ForEach(x => Debug.Log(x));
    
        }
    }
