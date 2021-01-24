	    private Object thisLock = new Object();
		private void button1_Click(object sender, EventArgs e)
		{
			Thread thr = new Thread(() =>
			{
				while (true)
				{pictureBox1.Invoke((Action)(() =>
						{
							screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
								Screen.PrimaryScreen.Bounds.Height);
							GFX = Graphics.FromImage(screenshot);
							GFX.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0,
								Screen.PrimaryScreen.Bounds.Size);
							pictureBox1.Image = screenshot;
						}));
					}
					Thread.Sleep(10);
			});
			thr.Start();
		}
