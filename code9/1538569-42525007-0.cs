	private void button1_Click(object sender, EventArgs e)
	{
		string msg = "";
		for (var i = 1; i < 6; i++)
		{
			for (var col = 0; col < i; i++)
			{
				msg += i;
			}
			msg += "\n";
		}
		MessageBox.Show(msg);
	}
