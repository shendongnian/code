    public static void SetSpriteFromPath(string path, Image image)
    {
        if(string.IsNullOrEmpty(path) == true){ throw new ArgumentException(); }
        if(image == null) { throw new ArgumentException(); }
        if(File.Exists(path))   { throw new Argument Exception();  }
        byte[] bytes = File.ReadAllBytes(path);
        if(bytes == null)
        { 
           Debug.LogError("Something went wrong with loading the file");
           return; 
        }
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(bytes);
        Sprite sprite = mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        image.sprite= sprite;
    }
