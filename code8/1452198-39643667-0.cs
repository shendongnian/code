    // New class fields
    private ButtonState _previousButtonState = ButtonState.Released;
    private int _previousMouseX;
    private int _previousMouseY;
    // New Update() method
    public void Update(GameTime gt)
    {
        MouseState mouseState = Mouse.GetState();
        // Check if the left button was clicked (pressed now, but not last Update())
        if (mouseState.LeftButton == ButtonState.Pressed && _previousButtonState != ButtonState.Pressed)
            OnMouseLeftClick(mouseState);
        _previousButtonState = mouseState.LeftButton;
     
        // See if the mouse has moved since the last Update()
        if (mouseState.X != _previousMouseX || mouseState.Y != _previousMouseY)
        {
            OnMouseMoved(mouseState);
            _previousMouseX = mouseState.X;
            _previousMouseY = mouseState.Y;
        }   
    }
