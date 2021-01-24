    public void AddTerrain(List<Entity> ents, int selector, int x, int y)
    {
        Terrain newT = new Terrain(new Vector2(x, y));
        ents.Add(newT);
        var animation = newT.Animation;
        animation.setImageIndex(selector);
        if (selector > 0)
        {
            animation.setSpeed(69);
        }
        animation.Play();
    }
    public List<Entity> LoadLevel(Level level)
    {
        List<Entity> ents = new List<Entity>();
        var colorMap = level.getColorMap;
        int colorMapWidth = colorMap.Width;
        int colorMapHeight = colorMap.Height;
        Color[] clrs = new Color[colorMapWidth * colorMapHeight];
        Color[] colors = new Color[] { new Color(0, 0, 0), new Color(6, 6, 6), new Color(9, 9, 9) };
        colorMap.GetData(clrs);
        int ci = 0;
        for (int y = 0; y < colorMapHeight; y++)
        {
            for (int x = 0; x < colorMapWidth; x++)
            {
                Color c = clrs[ci++];
                for (int i = 0; i < colors.Length; ++i)
                {
                    if (c == colors[i])
                    {
                        AddTerrain(ents, c.R, x, y);
                        break;
                    }
                }
            }
        }
        return ents;
    }
