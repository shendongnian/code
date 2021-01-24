    void Start()
    {
        StartCoroutine(LoadImage(CreateSpriteFromTexture));
    }
    private CreateSpriteFromTexture(Texture2D texture)
    {
            if(texture == null) { return;}
            Sprite sprite = Sprite.Create(texture,
                new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            // Assign sprite to image
    }
