    public class B_Null : Canvas
    {
        private Ellipse Ellipse = new Ellipse();
        public B_Null()
        {
            Ellipse.Width = 200;
            Ellipse.Height = 200;
            Ellipse.Stroke = Brushes.Red;
            Ellipse.StrokeThickness = 1;
            Ellipse.Fill = Brushes.Red;
            this.Children.Add(Ellipse);
        }
    }
