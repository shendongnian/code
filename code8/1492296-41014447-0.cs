    internal class SingleAnimations
    {
        public static DoubleAnimation SetToZero(object sender)
        {
            var element = sender as UIElement;
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.BeginTime = new TimeSpan(0, 0, 0, 0, 0);
            doubleAnimation.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 0));
            doubleAnimation.From = 1;
            doubleAnimation.To = 0;
            Storyboard.SetTarget(doubleAnimation, element);
            Storyboard.SetTargetProperty(doubleAnimation, "Opacity");
            return doubleAnimation;
    
        }
    
        public static DoubleAnimation SimpleElementFadeIn(object sender, int fadeTime, int delay)
        {
            var element = sender as UIElement;
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.BeginTime = new TimeSpan(0, 0, 0, 0, delay);
            doubleAnimation.Duration = new Duration(new TimeSpan(0, 0, 0, 0, fadeTime));
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            Storyboard.SetTarget(doubleAnimation, element);
            Storyboard.SetTargetProperty(doubleAnimation, "Opacity");
            return doubleAnimation;
    
        }
