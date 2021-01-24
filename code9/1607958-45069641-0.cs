    public void Resize(Sprite sprite)
    {
        Texture2D tex = sprite.texture;
    
        tex.Resize(100, 100, TextureFormat.RGBA32, false);
    
        Sprite n_spr = Sprite.Create(tex,
            new Rect(0, 0, tex.width, tex.height),
            new Vector2(0.5f, 0.5f), 100.0f);
    
        AssetSaver.CreateAsset(n_spr, sprite.name + "_dtx5");
    }
