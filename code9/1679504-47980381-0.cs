    Dictionary<string, CDinfo> MS = new Dictionary<string, CDinfo>(); // initialize the dictionary somewhere outside of your click handler
    
    private void button1_Click(object sender, EventArgs e)
    {
    	CDinfo lolo = new CDinfo();
    	string name;
    	name = textBox1.Text;
    	lolo.type = textBox2.Text;
    	lolo.code = textBox3.Text;
    	lolo.count = int.Parse(count.Text);
    	
    	// add to the dictionary here
    	MS.Add(name, lolo);
    }
