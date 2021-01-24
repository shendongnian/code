    bool paintmode = false;
    
    // Assign this to all labels, since you don't know
    // where the user will start painting
    private void Mouse_Down(object sender, MouseEventArgs e)
    {
       paintmode = true;
    }
    
    // Make sure you assign this to all items, even the Form
    // as you'll never know where the user will release the mouse
    private void Mouse_Up(object sender, MouseEventArgs e)
    {
       paintmode = false;
    }
    
    // Assign this only to labels which can get painted
    private void Mouse_Enter(object sender, MouseEventArgs e)
    {
        if (paintmode)
        {
            var ActiveLabel = sender as Label;
            if (ActiveLabel != null)
            {
                ActiveLabel.BackColor = ActiveColor.BackColor;
            }
        }
    }
