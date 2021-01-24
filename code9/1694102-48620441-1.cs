    protected void OnComboBox1Changed(object sender, EventArgs e)
	{
        string text = combobox1.ActiveText;
        
        Console.WriteLine( text );
        this.Title = "Chosen: " + text; 
        label1.Text = text;
	}
