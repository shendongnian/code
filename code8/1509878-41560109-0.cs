    protected override Size MeasureOverride(Size constraint)
    {
         Size desiredSize = new Size();
         foreach (UIElement child in InternalChildren)
         {
             child.Measure(constraint);
             desiredSize.Height = child.DesiredSize.Height;
             desiredSize.Width = constraint.Width;
         }
         return desiredSize;
     }
     protected override Size ArrangeOverride(Size arrangeSize)
      {
            double offset = 0;
            double properWidth = arrangeSize.Width / InternalChildren.Count;
            foreach (UIElement child in InternalChildren)
            {
                 child.Arrange(new Rect(offset, 0, properWidth, arrangeSize.Height));
                 offset += properWidth;
            }
            return arrangeSize;
        }
