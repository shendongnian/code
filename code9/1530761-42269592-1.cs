    public class Circles : Canvas
    {
        public Circles()
        {
            for (int i = 1; i < 30*15; i+=15)
            {
                var e = new Border() { Width = 10, Height = 10, Background = Brushes.Red };
                SetTop(e, i);
                SetLeft(e, i);
                Children.Add(e);
                e.MouseEnter += E_MouseEnter;
                e.MouseLeave += E_MouseLeave;
            }
        }
        private void E_MouseLeave(object sender, MouseEventArgs e)
        {
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer((UIElement)sender);
            if (adornerLayer != null)
            {
                Adorner[] adorners = adornerLayer.GetAdorners((UIElement)sender);
                if (adorners != null)
                {
                    foreach (Adorner adorner in adorners)
                        adornerLayer.Remove(adorner);
                }
            }
        }
        private void E_MouseEnter(object sender, MouseEventArgs e)
        {
            SimpleCircleAdorner ad = new SimpleCircleAdorner((UIElement)sender) { Tag = sender };
            AdornerLayer adLayer = AdornerLayer.GetAdornerLayer((UIElement)sender);
            adLayer.Add(ad);
        }
   
    }
    public class SimpleCircleAdorner : Adorner
    {
        // Be sure to call the base class constructor.
        public SimpleCircleAdorner(UIElement adornedElement)
          : base(adornedElement)
        {
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            Panel p = FindAncestor<Panel>((UIElement)Tag);
            foreach (Border ui in p.Children)
            {
                ui.Width += 1;
                ui.Height += 1;
            }
        }
        public static T FindAncestor<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            while (true)
            {
                if (dependencyObject == null)
                    return null;
                var parent = VisualTreeHelper.GetParent(dependencyObject) ??
                             LogicalTreeHelper.GetParent(dependencyObject);
                var parentT = parent as T;
                if (parentT != null)
                    return parentT;
                dependencyObject = parent;
            }
        }
        // A common way to implement an adorner's rendering behavior is to override the OnRender
        // method, which is called by the layout system as part of a rendering pass.
        protected override void OnRender(DrawingContext drawingContext)
        {
            Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize);
            // Some arbitrary drawing implements.
            SolidColorBrush renderBrush = new SolidColorBrush(Colors.Green);
            renderBrush.Opacity = 0.2;
            Pen renderPen = new Pen(new SolidColorBrush(Colors.Navy), 1.5);
            double renderRadius = 5.0;
            // Draw a circle at each corner.
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopLeft, renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopRight, renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomLeft, renderRadius, renderRadius);
            drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomRight, renderRadius, renderRadius);
        }
    }
