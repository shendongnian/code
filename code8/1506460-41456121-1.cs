    [CustomEditor(typeof(Tile))]
    public class TileEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            Tile tile = (Tile)target;
    
            // Create a dropdown list of tile types
            tile.type = (TileType)EditorGUILayout.EnumPopup("TileType", tile.type);
    
            Debug.Log("OnInspectorGUI");
    
            switch (tile.type)
            {
                case TileType.Blank:
                    tile.GetComponent<Renderer>().material = Resources.Load("Materials/Blank Tile", typeof(Material)) as Material;
                    Debug.Log("Blank");
                    break;
                case TileType.Portal:
                    tile.GetComponent<Renderer>().material = Resources.Load("Materials/Portal Tile", typeof(Material)) as Material;
                    Debug.Log("Portal");
                    break;
            }
        }
    }
    
    public enum TileType
    {
        Blank,
        Portal
    }
