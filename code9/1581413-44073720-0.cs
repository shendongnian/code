    if(childNode.IsSelected)
    {
         CurrentNode = ForeGroundBrushHighLight;
         e.Graphics.FillRectangle(BackGroundBrushHighLight, childNode.Bounds);
    }
    else
    {
         CurrentNode = ForeGroundBrush;
    }
    if(childNode.Parent.IsExpanded)
    {
         e.Graphics.DrawString(childNode.Text, this.Font, CurrentNode, Rectangle.Inflate(childNode.Bounds, 2, 0));
    }
