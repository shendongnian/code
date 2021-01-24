	private void timer2_Tick(object sender, EventArgs e)
	{
		pictureBox7.Hide();
		if ((pictureBox3.Bounds.IntersectsWith(pictureBox2.Bounds) && pictureBox2.Visible) 
			|| (pictureBox5.Bounds.IntersectsWith(pictureBox2.Bounds) && pictureBox2.Visible))
		{                
			puntaje++;
			this.Text = "Puntaje: " + puntaje;
			if (puntaje % 5 == 0)
			{
				var timer3 = new Timer(TimeSpan.FromSeconds(16).TotalMilliseconds) { AutoReset = false };
				timer3.Elapsed += (sender, e) =>
				{
					pictureBox3.Visible = true;
				};
				timer3.Start();
			}
		}
	}
