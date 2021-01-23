    delegate void SetTextCallback1(string name);
	private void SetTextLabel(string name)
	{
		if (this.label1.InvokeRequired)
		{
			SetTextCallback1 d = new SetTextCallback1(SetTextLabel);
			this.Invoke(d, new object[] { name });
		}
		else
		{
			this.label1.Text = name;
		}
	}
