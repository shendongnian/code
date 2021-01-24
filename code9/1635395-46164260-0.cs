    // Boolean flag used to determine when a character other than a space is entered
    private bool spaceEntered = false;
    
    // Handle the KeyDown event to determine the type of character entered into the control.
    private void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        spaceEntered = e.KeyCode == Keys.Space;
    }
    
    // This event occurs after the KeyDown event and can be used to prevent
    // characters from entering the control.
    private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        // Check for the flag being set in the KeyDown event.
        if (spaceEntered == true)
        {
            // Stop the character from being entered into the control since 
            e.Handled = true;
        }
    }
