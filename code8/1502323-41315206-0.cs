    public class AtlasLoader
    {
        public Dictionary<string, Sprite> spriteDic = new Dictionary<string, Sprite>();
    
        //Creates new Instance only, Manually call the loadSprite function later on 
        public AtlasLoader()
        {
    
        }
    
        //Creates new Instance and Loads the provided sprites
        public AtlasLoader(string spriteBaseName)
        {
            loadSprite(spriteBaseName);
        }
    
        //Loads the provided sprites
        public void loadSprite(string spriteBaseName)
        {
            Sprite[] allSprites = Resources.LoadAll<Sprite>(spriteBaseName);
            if (allSprites == null || allSprites.Length <= 0)
            {
                Debug.LogError("The Provided Base-Atlas Sprite `" + spriteBaseName + "` does not exist!");
                return;
            }
    
            for (int i = 0; i < allSprites.Length; i++)
            {
                spriteDic.Add(allSprites[i].name, allSprites[i]);
            }
        }
    
        //Get the provided atlas from the loaded sprites
        public Sprite getAtlas(string atlasName)
        {
            Sprite tempSprite;
    
            if (!spriteDic.TryGetValue(atlasName, out tempSprite))
            {
                Debug.LogError("The Provided atlas `" + atlasName + "` does not exist!");
                return null;
            }
            return tempSprite;
        }
    
        //Returns number of sprites in the Atlas
        public int atlasCount()
        {
            return spriteDic.Count;
        }
    }
