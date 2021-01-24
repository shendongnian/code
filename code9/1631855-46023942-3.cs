    public void button2_Click(object sender, EventArgs e)
    {
    	var new1=dataGridView2.Rows[0].Cells[2].Value; 
    	order = new1.ToString();
    	
    	Form2 f2 = new Form2();
    	f2.strarry = ordernew.Split(','); //surprise!! I don't know where you get ordernew variable but anyways, assign your values HERE...
    	f2.Show();
    }
