	private void Grid_PreviewMouseMove(object sender, MouseEventArgs e)
	{
		Grid g = sender as Grid;
		
		if (g != null)
		{
			g.Height = 200;
			g.Width = 200;
		}
		System.Diagnostics.Debug.WriteLine("Sender: " + sender.GetType() + "; Source: " + e.Source.GetType());
	}
	private void Ellipse_PreviewMouseMove(object sender, MouseEventArgs e)
	{
		Ellipse el = sender as Ellipse;
		
		if (el != null)
		{
			el.Height = 60;
			el.Width = 60;
			el.Fill = Brushes.White;
		}
		System.Diagnostics.Debug.WriteLine("Sender: " + sender.GetType() + "; Source: " + e.Source.GetType());
	}
	private void Label_PreviewMouseMove(object sender, MouseEventArgs e)
	{
		Label l = sender as Label;
		
		if (l != null)
		{
			l.Foreground = Brushes.Black;
		}
		System.Diagnostics.Debug.WriteLine("Sender: " + sender.GetType() + "; Source: " + e.Source.GetType());
	}
