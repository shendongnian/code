        public class OneRowPanel:Panel
        {
            double itemHeight=0;
            protected override Size MeasureOverride(Size availableSize)
            {
                int count = Children.Count;
                foreach (FrameworkElement child in Children)
                {
                    child.Measure(new Size(availableSize.Width/count,availableSize.Height));
                    if (child.DesiredSize.Height > itemHeight)
                    {
                        itemHeight = child.DesiredSize.Height;
                    };
                }
            
                // return the size available to the whole panel
                return new Size(availableSize.Width, itemHeight);
            }
            protected override Size ArrangeOverride(Size finalSize)
            {
                // Get the collection of children
                UIElementCollection mychildren = Children;
                // Get total number of children
                int count = mychildren.Count;
                // Arrange children
                int i;
                for (i = 0; i < count; i++)
                {
                    //get the item Origin Point
                    Point cellOrigin = new Point(finalSize.Width / count * i,0);
                    // Arrange child
                    // Get desired height and width. This will not be larger than 100x100 as set in MeasureOverride.
                    double dw = mychildren[i].DesiredSize.Width;
                    double dh = mychildren[i].DesiredSize.Height;
                    mychildren[i].Arrange(new Rect(cellOrigin.X, cellOrigin.Y, dw, dh));
                }
            
                // Return final size of the panel
                return new Size(finalSize.Width, itemHeight);
            }
        }
