    Random rnd = new Random();
    private void Button_MouseEnter(object sender, MouseEventArgs e)
    {
        //Work out where the button is going to move to.
        double newLeft = rnd.Next(Convert.ToInt32(cnv.ActualWidth - btn.ActualWidth));
        double newTop = rnd.Next(Convert.ToInt32(cnv.ActualHeight - btn.ActualHeight));
        //Create the animations for left and top
        DoubleAnimation animLeft = new DoubleAnimation(Canvas.GetLeft(btn), newLeft, new Duration(TimeSpan.FromSeconds(1)));
        DoubleAnimation animTop = new DoubleAnimation(Canvas.GetTop(btn), newTop, new Duration(TimeSpan.FromSeconds(1)));
        //Set an easing function so the button will quickly move away, then slow down
        //as it reaches its destination.
        animLeft.EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut };
        animTop.EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut };
        //Start the animation.
        btn.BeginAnimation(Canvas.LeftProperty, animLeft, HandoffBehavior.SnapshotAndReplace);
        btn.BeginAnimation(Canvas.TopProperty, animTop, HandoffBehavior.SnapshotAndReplace);
    }
