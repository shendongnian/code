    private void button1_Click(object sender, EventArgs e)
    {
    	if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
    	{
    		label2.Text = "Bitte 2 Zahlen eingeben";
    	}
    	else
    	{
    		Zahl1 = Convert.ToDouble(textBox1.Text); 
    		Zahl2 = Convert.ToDouble(textBox2.Text); 
    		label2.Text = label2.Text.Replace(".", ",");
    
    	}
    }
