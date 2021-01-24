	List<Rectangle> difList = new List<Rectangle>();
	List<Rectangle> leftList = new List<Rectangle>();
	List<RectangleInfo> bottomList = new List<RectangleInfo>();
	List<Rectangle> rightList = new List<Rectangle>();
	private void AccumulateDifferences(Rectangle scanArea, Side direction)
	{
		Rectangle foundRect = Locate(scanArea);
		if (foundRect == null)
			return; // stop the recursion.
		switch (direction)
		{
			case Side.Left:
				if (foundRect.X == scanArea.X + scanArea.Width)
					leftList.Add(foundRect);
				else difList.Add(foundRect);
				break;
			case Side.Bottom:
				bottomList.Add(new RectangleInfo(foundRect, foundRect.X == scanArea.X, foundRect.X + foundRect.Width == scanArea.X + scanArea.Width));
				break;
			case Side.Right:
				if (foundRect.X + foundRect.Width == scanArea.X)
					rightList.Add(foundRect);
				else difList.Add(foundRect);
				break;
		}
		Rectangle leftArea = new Rectangle(scanArea.X, foundRect.Y, (foundRect.X - scanArea.X), (scanArea.Y + scanArea.Height) - (foundRect.Y + foundRect.Height)); // define left area.
		Rectangle bottomArea = new Rectangle(foundRect.X, foundRect.Y + foundRect.Height, foundRect.Width, (scanArea.Y + scanArea.Height) - (foundRect.Y + foundRect.Height)); // define bottom area.
		Rectangle rightArea = new Rectangle(foundRect.X + foundRect.Width, foundRect.Y, (scanArea.X + scanArea.Width) - (foundRect.X + foundRect.Width), (scanArea.Y + scanArea.Height) - (foundRect.Y + foundRect.Height)); //define right area.
		AccumulateDifferences(leftArea, Side.Left);
		AccumulateDifferences(bottomArea, Side.Bottom);
		AccumulateDifferences(rightArea, Side.Right);
	}
	private void ProcessDifferences()
	{
		foreach (RectangleInfo rectInfo in bottomList)
		{
			if (rectInfo.LeftOverlap)
			{
				Rectangle leftPart =
					leftList.Find(r => r.X + r.Width == rectInfo.Rectangle.X
									   && r.Y == rectInfo.Rectangle.Y
									   && r.Height == rectInfo.Rectangle.Height
								 );
				if (leftPart != null)
				{
					rectInfo.Rectangle.X = leftPart.X;
					leftList.Remove(leftPart);
				}
			}
			if (rectInfo.RightOverlap)
			{
				Rectangle rightPart =
					rightList.Find(r => r.X == rectInfo.Rectangle.X + rectInfo.Rectangle.Width
										&& r.Y == rectInfo.Rectangle.Y
										&& r.Height == rectInfo.Rectangle.Height
								  );
				if (rightPart != null)
				{
					rectInfo.Rectangle.X += rightPart.Width;
					rightList.Remove(rightPart);
				}
			}
			difList.Add(rectInfo.Rectangle);
		}
		difList.AddRange(leftList);
		difList.AddRange(rightList);
	}
	private void LocateDifferences(Rectangle scanArea)
	{
		AccumulateDifferences(scanArea, Side.Left);
		ProcessDifferences();
		leftList.Clear();
		bottomList.Clear();
		rightList.Clear();
	}
