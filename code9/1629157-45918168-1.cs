    double z1;
	double z2;
    if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
	{
		label2.Text = "Bitte 2 Zahlen eingeben";
	}
	else if (!double.TryParse(textBox1.Text, out z1) || !double.TryParse(textBox2.Text, out z2))
	{
		label2.Text = "Das sind keine korekt Zahlen! :)";
	}
	else
	{
        //rest of your code
        Zahl1 = Convert.ToDouble(textBox1.Text); 
        //etc....
    }
