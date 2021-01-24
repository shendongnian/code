    private int correctCounter = 0; // Somewhere in code
    private int incorrectCounter = 0; // Somewhere in code
    
    private void button2_Click(object sender, EventArgs e)
    {
        string s = (sender as Button).Text; // Or ((Button)sender).Text;
        if(s == "Correct") {
            correctCounter += 1;
        } else {
            incorrectCounter += 1;
        }
        // Do other things
    }
