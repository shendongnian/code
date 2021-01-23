    public sealed class FeatureControl : IFeatureControl
    {
        public static IFeatureControl Current { get; }
    
        static FeatureControl()
        {
            Current = new FeatureControl();
        }
    }
