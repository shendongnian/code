    public class DoubleAnimationWithSteps : DoubleAnimation
    {
        public static readonly DependencyProperty StepProperty = DependencyProperty.Register(
            nameof(Step), typeof(double), typeof(DoubleAnimationWithSteps));
        public double Step
        {
            get { return (double)GetValue(StepProperty); }
            set { SetValue(StepProperty, value); }
        }
        protected override double GetCurrentValueCore(
            double from, double to, AnimationClock animationClock)
        {
            var value = base.GetCurrentValueCore(from, to, animationClock);
            if (Step > 0d)
            {
                value = Step * Math.Floor(value / Step);
            }
            return value;
        }
        protected override Freezable CreateInstanceCore()
        {
            return new DoubleAnimationWithSteps();
        }
    }
