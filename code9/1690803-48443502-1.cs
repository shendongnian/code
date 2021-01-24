	private void label1_Paint(object sender, PaintEventArgs e)
	{
		if (changeBorder)
		{
			ControlPaint.DrawBorder(e.Graphics, this.label1.ClientRectangle,
						  Color.Red, 0, ButtonBorderStyle.Solid,
						  Color.Red, 2, ButtonBorderStyle.Solid,
						  Color.Red, 0, ButtonBorderStyle.Solid,
						  Color.Red, 2, ButtonBorderStyle.Solid);
		}
		else
			ControlPaint.DrawBorder(e.Graphics, ClientRectangle, this.BackColor, ButtonBorderStyle.None);
		}
