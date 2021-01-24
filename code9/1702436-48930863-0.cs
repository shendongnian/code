    // Drag & Drop the object holding the script to the `OnClick` listener of your button
    // Then, simply select the `Pickup` function
    public void Pickup()
    {
        // code ....
    }
    
    private void Update()
    {
        if( Input.GetKeyDown( KeyCode.F ) )
            Pickup() ;
    }
