    protected void Button1_Click(object sender, EventArgs e)
    {
        int a;
        int b;
        if(Int32.TryParse(textBox1.Text, out a) && Int32.TryParse(textBox2.Text, b))
        {
            // Calculate works with A and B variables
            // don't know whats here as you written (//calculate - works) only
        }
        else
        {
            Error.Text = "Error parsing value! Wrong values!";
        }
    }
