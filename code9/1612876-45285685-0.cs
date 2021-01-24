    MouseState mouseState = Mouse.GetState();
    if (mouseState.LeftButton == ButtonState.Pressed)
    {
        end = new Vector2(mouseState.X, mouseState.Y);
        if (prevMouseState.LeftButton == ButtonState.Released)
        {
            start = end;
            selecting = true;
        }
    }
    else
        selecting = false;
    prevMouseState = mouseState;
