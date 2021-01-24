     public class enemy : MonoBehaviour {
        public Node nodeScript;
        private Node otherNodeScript; // Add this 
    
        // Use this for initialization
        void Start () {
            otherNodeScript = GameObject.Find("otherGameObjectName").GetComponent<Node>(); // Here bind your local Node reference to the actual instance
        }
    
        // Update is called once per frame
        void Update () {
    
            test();
            Debug.Log(otherNodeScript.FinalPath.Count); // change here
        }
    
        public void test()
        {
            otherNodeScript.FinalPath.ForEach(x => Debug.Log(x)); // change here
    
        }
    }
