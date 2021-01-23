    protected void Button1_Click(object sender, EventArgs e)
    {
        int a;
        int b;
        // Here we check if values are ok
        if(Int32.TryParse(textBox1.Text, out a) && Int32.TryParse(textBox2.Text, b))
        {
            // Calculate works with A and B variables
            // don't know whats here as you written (//calculate - works) only
        }
        // If the values of textBoxes are wrong display error message
        else
        {
            Error.Text = "Error parsing value! Wrong values!";
        }
    }
