    public static void getKeyPress(Keys key)
    {
        updated = Keyboard.GetState();
        if (updated.IsKeyDown(key))
        {
        }
        if (updated.IsKeyDown(Keys.Space))
        {
        }
    }
