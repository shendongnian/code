    	private void button1_Click(object sender, EventArgs e)
		{
			label1.Text = "Button Clicked";
			if (Control.ModifierKeys == Keys.Control) label1.Text += " with Ctrl";
		}
		private void button1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\n') button1_Click(sender, new EventArgs());
		}
