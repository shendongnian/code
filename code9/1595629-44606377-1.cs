	private Random R = new Random();
	private async void button1_Click(object sender, EventArgs e)
	{
		button1.Enabled = false;
		label1.AutoSize = false;
		label1.Size = button2.Size;
		Point p = new Point(R.Next(this.Width - button2.Width), R.Next(this.Height - button2.Height));
		label1.Location = p;
		label1.SendToBack();
		await MoveControl(button2, p, R.Next(2000, 7001));
		button1.Enabled = true;
	}
	private Task MoveControl(Control control, Point LocationEndPoint, int delayInMilliseconds)
	{       
		return Task.Run(new Action(() =>
		{
			decimal p;
			int startX = control.Location.X;
			int startY = control.Location.Y;
			int deltaX = LocationEndPoint.X - startX;
			int deltaY = LocationEndPoint.Y - startY;
			System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
			sw.Start();
		 
			while(sw.ElapsedMilliseconds < delayInMilliseconds)
			{
				System.Threading.Thread.Sleep(50);
				p = Math.Min((decimal)1.0, (decimal)sw.ElapsedMilliseconds / (decimal)delayInMilliseconds);
				control.Invoke((MethodInvoker)delegate {
					control.Location = new Point(startX + (int)(p * deltaX), startY + (int)(p * deltaY));
				});
			}
		}));
	}
