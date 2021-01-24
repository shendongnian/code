    public class RestrictiveWidthControl : ContentControl
    {
        protected override Size MeasureOverride(Size constraint)
        {
            // check constraint. If the constraint.Width is infinite, your parent layout is not ready for reliable grid sizing
            return base.MeasureOverride(constraint);
        }
    }
