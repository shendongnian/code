	private async void button1_Click(object sender, EventArgs e)
	{
		while (pictureBox2.Size.Width > 0)
		{
			int width = pictureBox2.Size.Width;
			width -= 2;
			pictureBox2.Size = new Size(width, pictureBox2.Size.Height);
			pictureBox2.Location = new Point(pictureBox2.Location.X + 1, pictureBox2.Location.Y);
			await Task.Delay(1);
		}
		pictureBox1.Image = currentImage;
		while (pictureBox2.Size.Width < 191)
		{
			int width = pictureBox2.Size.Width;
			width += 2;
			pictureBox2.Size = new Size(width, pictureBox2.Size.Height);
			pictureBox2.Location = new Point(pictureBox2.Location.X - 1, pictureBox2.Location.Y);
			await Task.Delay(1);
		}
	}
