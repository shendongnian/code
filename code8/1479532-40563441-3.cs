    public class TileScript : MonoBehaviour
    {
        public int tileGroupID = 0; //Indicates the Tile Group ID.
        public bool tileIsSelected = false; //If this Tile is Selected.
        public GameObject[] tilesArray; //Reference to Tiles Array.
    
        //Private
        private Rigidbody myRigidbody;
        private Renderer myRenderer;
        private Material tileDefaultMaterial;
        private Material tileSelectedMaterial;
        private Material tileSameGroupMaterial;
    
        private TilesManager tileManager;
    
        void Start()
        {
            tilesArray = GetComponentInParent<TilesManager>().tilesArray;
            myRigidbody = GetComponent<Rigidbody>();
            myRenderer = GetComponent<Renderer>();
            tileDefaultMaterial = Resources.Load("TileDefault", typeof(Material)) as Material;
            tileSelectedMaterial = Resources.Load("TileSelected", typeof(Material)) as Material;
            tileSameGroupMaterial = Resources.Load("TileSameGroup", typeof(Material)) as Material;
    
            //Get Tiles Manager
            GameObject tileManagerObj = GameObject.Find("Tiles");
            tileManager = tileManagerObj.GetComponent<TilesManager>();
        }
    
        void OnMouseDown()
        {
            //Let Tiles Manager know that there was a press on (this) Tile
            tileManager.OnObjectSelection(this.gameObject);
        }
    }
