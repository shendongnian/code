    private void panel1_Paint(object sender, PaintEventArgs e)
	{
		using (SolidBrush brush = new SolidBrush(Color.Black))
		{ 
			e.Graphics.DrawString(selectedText, this.Font, brush, new Point(0,0));                   
		}
	}
