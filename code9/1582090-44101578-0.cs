	private bool ValidData = false;
	private List<decimal> numbers = new List<decimal>();
	private void Form1_Load(object sender, EventArgs e)
	{
		button1.Enabled = false;
	}
	private void textBox1_TextChanged(object sender, EventArgs e)
	{
		ValidData = true; // assume it's all good until proven otherwise
		numbers.Clear();
		decimal value;
		string[] values = textBox1.Text.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
		for(int i = 0; i< values.Length; i++)
		{
			values[i] = values[i].Trim();
			if (decimal.TryParse(values[i], out value))
			{
				numbers.Add(value);
			}
			else
			{
				ValidData = false;                   
			}
		}
		button1.Text = ValidData ? "Process" : "Invalid Data";
		button1.Enabled = ValidData;
		listBox1.DataSource = null;
		listBox1.DataSource = numbers;
	}
	private void button1_Click(object sender, EventArgs e)
	{
		if (ValidData)
		{
			// do something with each number
			foreach(decimal value in numbers)
			{
				Console.WriteLine(value.ToString());
			}
		}
	}
