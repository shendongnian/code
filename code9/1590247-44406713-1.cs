    public class FeatureContextDriver
    {
        public void FeatureContextChangeing(FeatureContext featureContext)
        {
            var key = 'key';
            var val = 'val';
            featureContext.Add(key, val);
        }
    }
    [Binding]
    public class BaseSteps : Steps
    {
        [BeforeFeature]
        public static void BeforeFeatureStep(FeatureContext featureContext)
        {
            var featureContextDriver = new FeatureContextDriver();
            featureContextDriver.FeatureContextChangeing(featureContext);
        }
    } 
    
    [Binding]
    public class OtherStep : Steps
    {
        private FeatureContextDriver _featureContextDriver;
        public OtherStep(FeatureContextDriver featureContextDriver)
        {
            _featureContextDriver = featureContextDriver;
        }
        public void ExecuteStep() 
        {
            _featureContextDriver.FeatureContextChangeing(this.FeatureContext);
        }
    }
