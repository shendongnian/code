    public interface IFeatureControl { }
    public sealed class FeatureControl : IFeatureControl
    {
        public static IFeatureControl Current { get; }
    
        static FeatureControl()
        {
            if (Current == null)
            {
                Current = new FeatureControl();
            }
        }
    }
    
    [TestFixture]
    public class FeatureControlTests
    {
        [Test]
        public void IsFeatureControlSingleton()
        {
            IFeatureControl c1 = FeatureControl.Current;
            IFeatureControl c2 = FeatureControl.Current;
            Assert.AreSame(c1, c2);
        }
    }
