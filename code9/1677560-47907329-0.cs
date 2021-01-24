    [Flags]
    public enum ActionState
    {
        MoveLeft,
        MeveRight,
        FireLaser,
    }
    
    // stores the current state
    private ActionState _actionState;
    
    // set action state
    private void Game_Screen_KeyDown(object sender, KeyEventArgs e)
    {
        switch ( e.KeyCode )
        {
            case Keys.Left:
                _actionState |= ActionState.MoveLeft;
                break;
            case Keys.Right:
                _actionState |= ActionState.MoveRight;
                break;
            case Keys.Up:
                _actionState |= ActionState.FireLaser;
                break;
            default:
                break;
        }
    }
    
    // remove action state
    private void Game_Screen_KeyUp(object sender, KeyEventArgs e)
    {
        switch ( e.KeyCode )
        {
            case Keys.Left:
                _actionState &= ~ActionState.MoveLeft;
                break;
            case Keys.Right:
                _actionState &= ~ActionState.MoveRight;
                break;
            case Keys.Up:
                _actionState &= ~ActionState.FireLaser;
                break;
            default:
                break;
        }
    }
    
    // called from a timer every 20 milliseconds
    private void Game_Screen_LoopTimer_Tick(object sender, EventArgs e)
    {
        if ( _actionState.HasFlag( ActionState.MoveLeft ) && !_actionState.HasFlag( ActionState.MoveRight ) )
        {
            cannonBox.Location = new Point(cannonBox.Left - 2, cannonBox.Top); //Changes location of cannonBox to a new location to the left
        }
        if ( _actionState.HasFlag( ActionState.MoveRight ) && !_actionState.HasFlag( ActionState.MoveLeft ) )
        {
            cannonBox.Location = new Point(cannonBox.Left + 2, cannonBox.Top); //Changes location of cannonBox to a new location to the right
        }
        if ( _actionState.HasFlag( ActionState.FireLaser ) )
        {
            createLaser(); //Calls the method whenever Up arrow key is pressed
        }
    }
