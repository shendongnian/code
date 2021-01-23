    private bool buttonIsClicked = false;
    private void button1_Click(object sender, EventArgs e)
    {
        this.buttonIsClicked = true;
    
    }
    private void button1_Leave(object sender, EventArgs e)
    {
        if (this.buttonIsClicked)
        {
            this.buttonIsClicked = !this.buttonIsClicked;
            // show screen B
        }
    }
