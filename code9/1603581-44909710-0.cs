    Rectangle myRect = new Rectangle(100, 100, 48, 32);
    public void DrawMapItem(SpriteBatch batch, Rectangle viewRegion)
    {
        if (viewRegion.Contains(myRect))
        {
            //Render your object here with the SpriteBatch
        }
    }
