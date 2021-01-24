    for(int i = 0; i < this.Controls.Count; i++)
	{
		if(this.Controls[i] is TextBox) //skip buttons and labels
		{
			MessageBox.Show("" + this.Controls[i].Text);
		}
	}
