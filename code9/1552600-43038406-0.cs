    private void ButtonHasBeenPressed(object sender, int index)
    {
        // Get the button that the user pressed
        var pressedButton = (Button)sender;
        // Only do something if they clicked a "neutral" button
        if (pressedButton.BackColor == Color.BlanchedAlmond)
        {
            // The backcolor will be set based on whether or not blue is true or false
            var newBackColor = blue ? Color.Red : Color.Blue;
            // Get the index of the button that the user clicked
            var buttonToChangeIndex = index;
            // From where the user clicked, look down at each button below (index + 7)
            // until we find the last button that has a BlanchedAlmond backcolor
            while (buttonToChangeIndex + 7 < gameButtons.Count() && 
                   gameButtons[buttonToChangeIndex + 7].BackColor == Color.BlanchedAlmond)
            {
                    buttonToChangeIndex += 7; // Set to the index to point to this button
            }
            // Now we set that button's backcolor
            gameButtons[buttonToChangeIndex].BackColor = newBackColor;
            // Flip our blue flag
            blue = !blue;
        }
    }
