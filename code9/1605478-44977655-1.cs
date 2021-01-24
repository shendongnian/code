	private void Form1_MouseMove(object sender, MouseEventArgs e)
	{
		if (isconnected)
		{
			try
			{
				NetworkStream serverStream = clientSocket.GetStream();
				var BW = new BinaryWriter(serverStream);
				this.Cursor = new Cursor(Cursor.Current.Handle);
				int pX = Cursor.Position.X;
				int pY = Cursor.Position.Y;
				BW.Write(pX);
				BW.Write(pY);
			}
			catch (Exception ex)
			{
			}
		}
	}
	private void RecieveLoop()
	{
		if (clientSocket.Available > 0)
		{
			NetworkStream serverStream = clientSocket.GetStream();
			var BR = new BinaryReader(serverStream);
			try
			{
				int X = BR.ReadInt32();
				int Y = BR.ReadInt32();
				coordvalue.Invoke((MethodInvoker)(() => coordvalue.Text = ""));
				coordvalue.Invoke((MethodInvoker)(() => coordvalue.Text = $"{X} and {Y}"));
				coordvalue.Invoke((MethodInvoker)(() => coordvalue.Update()));
				////change coordinates
				System.Windows.Forms.Cursor.Position = new Point(Convert.ToInt32(X), Convert.ToInt32(Y));
				Cursor.Clip = new Rectangle(this.Location, this.Size);
				System.IO.File.AppendAllText(@"F:\DOWNLOAD\server.txt", $"{X} and {Y}" + Environment.NewLine);
			}
			catch (Exception E)
			{
				//  MessageBox.Show(E.ToString());
			}
		}
	}
