      private void Button_Click(object sender, RoutedEventArgs e)
      {
            Storyboard storyboard = new Storyboard();
            Duration duration = new Duration(TimeSpan.FromMilliseconds(2000));
            CubicEase ease = new CubicEase { EasingMode = EasingMode.EaseOut };
            DoubleAnimation animation = new DoubleAnimation();
            animation.EasingFunction = ease;
            animation.Duration = duration;
            storyboard.Children.Add(animation);
            animation.From = 1000;
            animation.To = 0;            
            Storyboard.SetTarget(animation, Col1);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(ColumnDefinition.MaxWidth)"));
            storyboard.Begin();
      }
