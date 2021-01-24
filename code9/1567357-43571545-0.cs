    private void textBox7_TextChanged(object sender, EventArgs e)
    {
    	listBox1.ClearSelected();
    	listBox1.DataSource = null;
    	foreach (Country name2 in Mytree.List)
    	{
    		if(name2.name.StartsWith(textBox7.Text)){
    			listBox1.Items.Add(name2.name);
    		}
    	}
    }
