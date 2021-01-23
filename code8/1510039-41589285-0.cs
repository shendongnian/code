    public class FixedCenterLinearAxis : LinearAxis
    {
        double center = 0;
        public FixedCenterLinearAxis() : base(){}
        public FixedCenterLinearAxis(double _center) : base()
        {
            center = _center;
        }
        public override void ZoomAt(double factor, double x)
        {
            base.ZoomAt(factor, center);
        }
    }
