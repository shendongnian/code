	public void IncreaseStudents(int num, out int result)
	{
		result = num + int.Parse(textBox3.Text);
	}
	private void button1_Click(object sender, EventArgs e)
	{
		School s1 = new School();
		s1._schlName = textBox1.Text;
		s1._schLevel = textBox2.Text;
		s1._stdNumber = int.Parse(textBox3.Text);
		int result;
		IncreaseStudents(25, out result);
		
		listBox1.Items.Add(s1._schlName);
		listBox1.Items.Add(s1._schLevel);
		listBox1.Items.Add(result); 
	}
