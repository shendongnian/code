	private void button1_Click(object sender, EventArgs e)
	{
		List<string> values = new List<string>(new string[] {"cats", "dogs", "fish", "lizard" });
		for(int i = 0; i < values.Count; i++)
		{
			Control match = this.Controls.Find("label" + (i + 1).ToString(), true).FirstOrDefault();
			if (match != null)
			{
				match.Text = values[i];
			}
		}
	}
