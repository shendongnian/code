    private void StoreFrame_OnManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
     {
         Transform.TranslateY += e.Delta.Translation.Y;
    
         var duration = new Duration(TimeSpan.FromMilliseconds(1000));
         var ease = new CubicEase { EasingMode = EasingMode.EaseOut };
         var animation = new DoubleAnimation
         {
             EasingFunction = ease,
             Duration = duration
         };
         var conStoryboard = new Storyboard();
         conStoryboard.Children.Add(animation);
         animation.From = Transform.TranslateY;
         animation.To = Transform.TranslateY += e.Delta.Translation.Y;
         animation.EnableDependentAnimation = false;
         Storyboard.SetTarget(animation, StoreFrame);
         Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(CompositeTransform.TranslateY)");
         conStoryboard.Begin();
     }
