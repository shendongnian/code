    public class MScrollBar : System.Windows.Controls.Primitives.ScrollBar
    { 
        protected override void OnMaximumChanged(double oldMaximum, double newMaximum)
        {
            // do stuff
            base.OnMaximumChanged(oldMaximum, newMaximum);
        }
    }
