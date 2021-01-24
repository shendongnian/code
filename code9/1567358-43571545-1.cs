    private void textBox7_TextChanged(object sender, EventArgs e)
    {
    	listBox1.ClearSelected();
    	listBox1.DataSource = null;
        var matchingCountries = Mytree.List.Where(l=>l.name.StartsWith(textBox7.Text));
    	foreach (Country name2 in matchingCountries)
    	{
    			listBox1.Items.Add(name2.name);
    	}
    }
