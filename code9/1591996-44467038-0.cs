	private void SetText(string text)
	{
		if (this.InvokeRequired)
		{
			this.Invoke((MethodInvoker)delegate
			{
				this.textBox1.Text = text;
			});
		}
		else
		{
			this.textBox1.Text = text;
		}
	}
