    public class SetTower : MonoBehaviour
    {
        public int selected;
        public GameObject[] towers;
        public float[] prices;
        public GameObject tile;
    
        private Money moneyScript;
    
        // Use this for initialization
        void Start()
        {
            moneyScript = GameObject.Find("GameLogic").GetComponent<Money>();
        }
    
        // Update is called once per frame
        void Update()
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero, 20);
    
            if (hit)
            {
                if (hit.transform.tag == "Tile")
                {
                    tile = hit.transform.gameObject;
                }
                else
                {
                    tile = null;
                }
    
                if (Input.GetMouseButtonDown(0) && tile != null)
                {
                    TileTaken tileScript = tile.GetComponent<TileTaken>();
    
                    if (!tileScript.isTaken && moneyScript.money >= prices[selected])
                    {
                        //moneyScript.money -= prices[selected];
                        Vector2 pos = new Vector2(tile.transform.position.x, tile.transform.position.y);
    
                        //tileScript.tower = (GameObject)Instantiate(towers[selected], pos, Quaternion.identity);
                        //tileScript.isTaken = true;
                    }
                }
            }
        }
    }
