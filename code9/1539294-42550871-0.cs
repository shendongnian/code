    public class TextBlockBehavior : Behavior<TextBlock>
    { 
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SizeChanged += AssociatedObject_SizeChanged; 
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SizeChanged -= AssociatedObject_SizeChanged;
        }
        private void AssociatedObject_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            TextBlock temp = new TextBlock()
            {
                Text = AssociatedObject.Text,
                LineStackingStrategy = AssociatedObject.LineStackingStrategy,
                LineHeight = AssociatedObject.LineHeight,
                TextTrimming = TextTrimming.None,
                TextWrapping = AssociatedObject.TextWrapping,
                Height = AssociatedObject.Height
            };
            double maxwidth = AssociatedObject.MaxWidth - 10;
            double desiredHeight = double.PositiveInfinity;
            while (desiredHeight > AssociatedObject.MaxHeight)
            { 
                temp.Measure(new Size(maxwidth, double.PositiveInfinity));
                maxwidth += 10;
                desiredHeight = temp.DesiredSize.Height;
            }
            AssociatedObject.MaxWidth = maxwidth;
            
        }
    }
