    public class TilesManager : MonoBehaviour
    {
        public GameObject[] tilesArray; //Aray of all Tiles GameObject.
        public Material tileSelectedMaterial;
    
        void Start()
        {
            tilesArray = new GameObject[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                tilesArray[i] = transform.GetChild(i).gameObject;
            }
        }
    
        //Will be called from  the TileScript(Receives any tile that is selected)
        public void OnObjectSelection(GameObject selectedObj)
        {
            //Change Material of the Selected GameObject
            selectedObj.GetComponent<MeshRenderer>().material = tileSelectedMaterial;
    
            //Change Mateial of other GameObjects that matches the  tileGroupID of the selectedObj
            findTheSameTileGroupIDAndChangeColor(selectedObj);
        }
    
        void findTheSameTileGroupIDAndChangeColor(GameObject selectedObj)
        {
            //Get the TileScript attached to the selectedObj
            TileScript selectedTileScript = selectedObj.GetComponent<TileScript>();
    
            //Loop through all GameObject in the array
            for (int i = 0; i < tilesArray.Length; i++)
            {
                /* 
                   Make sure this is NOT selectedObj since we've arleady 
                   changed its Material in OnObjectSelection function
                */
                if (selectedObj != tilesArray[i])
                {
                    //Get TileScript attached to the current Tile loop
                    TileScript tileLoop = tilesArray[i].GetComponent<TileScript>();
                    //Check if selectedObj and the current loop tileGroupID matches
                    if (selectedTileScript.tileGroupID == tileLoop.tileGroupID)
                    {
                        //It matches! Now, change it's color
                        tileLoop.GetComponent<MeshRenderer>().material = tileSelectedMaterial;
                    }
                }
            }
        }
    }
