    // Fields
    readonly KeyCode[] allKeyStates;
    HashSet<KeyCode> state = new HashSet<KeyCode>();
    float speed = 120; // 120 pixels/second.
    
    private void Form_KeyDown(object sender, KeyEventArgs args)
    {
        var key = args.KeyCode;
        state.Add(key);
        // Fire pressed when a key was up.
        if (!state.Contains(key)) {
            state.Add(key);
            OnKeyPressed(key);
        }
    }
    
    private void Form_KeyUp(object sender, KeyEventArgs args)
    {
        var key = args.KeyCode;
        state.Remove(key);
        // Fire release when a key was down.
        if (state.Contains(key)) {
            state.Remove(key);
            OnKeyReleased(key);
        }
    }
    
    // Runs when key was up, but pressed just now.
    private void OnKeyPressed(KeyCode key)
    {
        // Trigger key-based actions.
    }
    
    // Runs when key was down, but released just now.
    private void OnReleased(KeyCode key)
    {
        // Trigger key-based actions, but on release instead of press.
    }
    private bool IsDown(KeyCode key)
    {
        return state.Contains(key);
    }
    // Trigger this periodically, at least 20 times a second(ideally 60).
    // An option to get you started is to use a windows timer, but 
    // eventually you'll want to use high precision timing instead.
    private void Update()
    {
        var deltaTime = // Calculate the seconds that have passed since the last update. 
        // Describing it is out of the scope of this answer, but see the links below.
        // Determine horizontal direction. Holding both 
        // A & D down cancels movement on the x-axis.
        var directionX = 0;
        if (IsDown(KeyCode.A)) {
            directionX--;
        }
        if (IsDown(KeyCode.D)) {
            directionX++;
        }
        // Determine vertical direction. Holding both 
        // W & S down cancels movement on the y-axis.
        var directionY = 0;
        if (IsDown(KeyCode.W)) {
            directionY--;
        }
        if (IsDown(KeyCode.S)) {
            directionY++;
        }
        // directionX & directionY should be normalized, but 
        // I leave that as an exercise for the reader.
        var movement = speed * deltaTime;
        var offsetX = directionX * movement;
        var offsetY = directionY * movement;
        MovePlayer(offsetX, offsetY);
    }
