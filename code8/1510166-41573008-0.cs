     private void MainPage_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            foreach (Rectangle child in LayoutRoot.Children)
            {
                child.Width += e.Cumulative.Scale;
                child.Height += e.Cumulative.Scale;
                //This is C#7 in case C#6 adapt
                if(child.RenderTransform is TranslateTransform tf)
                {
                    tf.X = LayoutRoot.Width / 2 - child.ActualWidth / 2;
                    tf.Y = LayoutRoot.Height / 2 - child.ActualHeight / 2;
                }
            }
        }
        private void Initialize()
        {
            var redbrush = new SolidColorBrush(Colors.Red);
            foreach (Rectangle child in LayoutRoot.Children)
            {
                child.Fill = redbrush;
                child.Height = 100;
                child.Width = 100;
                child.RenderTransformOrigin = new Point(0.5, 0.5);
                child.RenderTransform = new TranslateTransform();
            }
        }
