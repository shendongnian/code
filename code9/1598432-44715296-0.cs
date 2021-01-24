    Dictionary<string, List<Sprite>> buildingSprites;
    void Start()
    {
        LoadSprites();
    }
    void LoadSprites() {
        buildingSprites = new Dictionary<string, List<Sprite>>();
        Sprite[] sprites = Resources.LoadAll<Sprite>("gfx/");
        foreach (Sprite s in sprites) {
            string path = AssetDatabase.GetAssetPath(s);
            path = path.Remove(0, 17);
            addToDictionary(path, s);
        }
        string FOLDER_NAME = "/"; // FODLER NAME SHOULD BE LIKE /ABC/ ... OR / FOR ROOT DIRECTORY
        if (!buildingSprites.ContainsKey(FOLDER_NAME)) {
            Debug.LogWarning("Wheres the folder: " + FOLDER_NAME + "?");
            return;
        }
        
        foreach (Sprite s in getEntriesThatStartWith(FOLDER_NAME, false))
            Debug.Log(AssetDatabase.GetAssetPath(s));
        // GET A RANDOM SPRITE ?
        Sprite aRandomSprite =   (getRandomSprite ( getEntriesThatStartWith (FOLDER_NAME , true)));
    }
    Sprite getRandomSprite(List<Sprite> sprites){
        int randomIndex = Mathf.RoundToInt(Random.Range(0f, 1f) * sprites.Count );
        return sprites[randomIndex];
    }
    List<Sprite> getEntriesThatStartWith(string prefix, bool allowSubFolders){
        if (!allowSubFolders && buildingSprites.ContainsKey(prefix)) {
            return buildingSprites[prefix];
        }
        else if (allowSubFolders) {
            List<Sprite> allSubSprites = new List<Sprite>();
            foreach (string s in buildingSprites.Keys)
                if (s.StartsWith(prefix))
                    foreach (Sprite subSprite in buildingSprites[s])
                        allSubSprites.Add(subSprite);
            return allSubSprites;
        }
        return null;
    }
    
    void addToDictionary (string path_with_name , Sprite spriteToAdd ) {
        string path = getPath (path_with_name);
        List<Sprite> sprites = null;
        buildingSprites.TryGetValue (path , out sprites );
        
        if (sprites == null){
            sprites = new List<Sprite>();
            buildingSprites.Add(path, sprites);
        }
        sprites.Add(spriteToAdd);
    }
    string getPath (string path_with_name) {
        int firstIndex = path_with_name.IndexOf('/');
        int lastIndex = path_with_name.LastIndexOf('/');
        return path_with_name.Substring(firstIndex, lastIndex - firstIndex + 1);
    }
`
