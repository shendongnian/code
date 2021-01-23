    private void button1_Click(object sender, EventArgs e)
    {
        // Declare variables for addition
        int a, b;
        // If convertion of textbox values to integer is successful
        // If integer parsing is successful, the value entered in textbox1 will go to variable a
        // and the value entered in textboxb will go to variable b
        if (int.TryParse(textBox1.Text, out a) && int.TryParse(textBox2.Text, out b))
        {
             // Add a and b and assign display its value in label
             label1.Text = (a + b).ToString();
        }
     }
