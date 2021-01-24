      private AnimationTimeline StartRectangleMarginAnimation(Rectangle rectangle)
        {           
            Thickness t = new Thickness(rectangle.Margin.Left+20, rectangle.Margin.Top-50, rectangle.Margin.Right, rectangle.Margin.Bottom);
            ThicknessAnimation animation = new ThicknessAnimation(t, TimeSpan.FromMilliseconds(500));
            animation.EasingFunction = new ExponentialEase()
            {
                EasingMode = EasingMode.EaseOut,
                Exponent = -5
            };
            animation.Completed += (s, e) =>
            {
                // DO STUFF.
            };
            return animation;
        }
        private AnimationTimeline StartRectangleHeightAnimation(Rectangle rectangle)
        {
            return new DoubleAnimation(
                20,
                TimeSpan.FromMilliseconds(500));
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AnimationTimeline shrink = StartRectangleHeightAnimation(rectangle);
            AnimationTimeline move = StartRectangleMarginAnimation(rectangle);
            Storyboard.SetTarget(shrink, rectangle);
            Storyboard.SetTargetProperty(shrink, new PropertyPath(Rectangle.HeightProperty));
            Storyboard.SetTarget(move, rectangle);
            Storyboard.SetTargetProperty(move, new PropertyPath(Rectangle.MarginProperty));
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(shrink);
            storyboard.Children.Add(move);
            storyboard.Begin(this);
        }
