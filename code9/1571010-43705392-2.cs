    private void drawing_MouseMove(object sender, MouseEventArgs e)
	{
		if (e.MiddleButton == MouseButtonState.Pressed))
		{
			var lsPoint = e.GetPosition(this);
			var res = lsPoint - firstPoint;
			foreach (UIElement element in drawing.Children)
			{
				var transform = element.RenderTransform as MatrixTransform;
				var matrix = transform.Matrix;
				matrix.TranslatePrepend(res.X, res.Y);
				transform.Matrix = matrix;
			}                
			//udate first point
			firstPoint = lsPoint;
		}
	}
