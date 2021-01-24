    public class CustomPanel : Panel
    {
        private double _maxWidth;
        private double _maxHeight;
        protected override Size ArrangeOverride(Size finalSize)
        {
            var x = 0.0;
            var y = 0.0;
            foreach (var child in Children)
            { 
                if ((_maxWidth + x) > finalSize.Width)
                {
                    x = 0;
                    y += _maxHeight;
                }
                var newpos = new Rect(x, y, _maxWidth, _maxHeight);
                child.Arrange(newpos);
                x += _maxWidth;
            }
            return finalSize;
        }
        protected override Size MeasureOverride(Size availableSize)
        { 
            foreach (var child in Children)
            {
                child.Measure(availableSize);
                var desirtedwidth = child.DesiredSize.Width;
                if (desirtedwidth > _maxWidth)
                    _maxWidth = desirtedwidth;
                var desiredheight = child.DesiredSize.Height;
                if (desiredheight > _maxHeight)
                    _maxHeight = desiredheight;
            }            
            var itemperrow = Math.Floor(availableSize.Width / _maxWidth);
            var rows = Math.Ceiling(Children.Count / itemperrow);
            return new Size(itemperrow * _maxWidth,_maxHeight * rows );
        }
    }
