	System.Drawing.Drawing2D.GraphicsPath Ellipse = new System.Drawing.Drawing2D.GraphicsPath();
	Ellipse.AddEllipse(350, 200, 1100, 700);
	Point pt = new Point(x, y); // get your point from somewhere
	if (Ellipse.IsVisible(pt)) // test to see if the point is contained by the ellipse
	{
		// ...do something in here...
	}
