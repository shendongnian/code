    List<Tuple<int, int>> myTuple = new List<Tuple<int, int>>();
	private void timer1_Tick(object sender, EventArgs e)
	{
		pictureBoxPath.Refresh();
		
		myTuple.Add(new Tuple<int, int>(gPathBoylam, gPathEnlem));	
	}
	//
	// Summary:
	//     Draws an ellipse defined by a bounding rectangle specified by coordinates
	//     for the upper-left corner of the rectangle, a height, and a width.
	//
	// Parameters:
	//   pen:
	//     System.Drawing.Pen that determines the color, width,
	//      and style of the ellipse.
	//
	//   x:
	//     The x-coordinate of the upper-left corner of the bounding rectangle that
	//     defines the ellipse.
	//
	//   y:
	//     The y-coordinate of the upper-left corner of the bounding rectangle that
	//     defines the ellipse.
	//
	//   width:
	//     Width of the bounding rectangle that defines the ellipse.
	//
	//   height:
	//     Height of the bounding rectangle that defines the ellipse.
	//
	// Exceptions:
	//   System.ArgumentNullException:
	//     pen is null.
	private void pictureBoxPath_Paint(object sender, PaintEventArgs e)
	{	
		Pen myPen = new Pen(Color.Red, 3); // Create pen
		
		if(myTuple != null && myTuple.Any())
		{
			foreach (var tuple in myTuple)
			{	
				Rectangle rect = new Rectangle(Convert.ToInt16(tuple.Item1), Convert.ToInt16(tuple.Item2), 2, 2); // Create rectangle for ellipse
					
				e.Graphics.DrawEllipse(myPen, rect); // Draw ellipse to screen
			}
		}
	}
