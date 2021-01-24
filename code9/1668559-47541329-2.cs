    private int correctCounter = 0; // Declared at class level
    private int incorrectCounter = 0; // Declared at class level
    
    private void buttonsClicked(object sender, EventArgs e)
    {
        string s = (sender as Button).Text; // Or ((Button)sender).Text;
        if(s == "Correct") { // Change "Correct" to whatever the text of the button is
            correctCounter += 1;
        } else if (s == "Incorrect") {
            incorrectCounter += 1;
        }
        // Do other things
    }
