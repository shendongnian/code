    private void textBox1_TextChanged(object sender, EventArgs e)
	{
		if (textBox1.Text == "")  //desired text that the textBoxes shell contain
			MyData.textBox1Correct = true;
		else
			MyData.textBox1Correct = false;
	}
	private void textBox2_TextChanged(object sender, EventArgs e)
	{
		if (textBox2.Text == "")  //desired text that the textBoxes shell contain
			MyData.textBox2Correct = true;
		else
			MyData.textBox2Correct = false;
	}
    public class MyData
	{
		public static bool textBox1Correct { get; set; }
		public static bool textBox2Correct { get; set; }
		public bool textBoxesCorrect
		{
			get
			{
				if (textBox1Correct && textBox2Correct)
					return true;
				else
					return false;
			}
		}
	}
