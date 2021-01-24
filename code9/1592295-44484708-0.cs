	private void button1_Click(object sender, EventArgs e)
	{
		Panel pnl = new Panel();
		pnl.BorderStyle = BorderStyle.FixedSingle;
		pnl.BackColor = Color.Red;
		Button btn = new Button();
		btn.Text = "Toggle Panel";
		btn.Tag = pnl;
		btn.Click += delegate {
			Panel p = (Panel)btn.Tag;
			p.Visible = !p.Visible;
		};
		flowLayoutPanel1.Controls.Add(btn);
		flowLayoutPanel1.Controls.Add(pnl);
	}
