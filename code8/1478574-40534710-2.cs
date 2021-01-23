    public class BaseView : UIViewController
    {
    
        static List<Type> SupportingLandscapeScreenTypes = new List<Type>()
        {
            typeof(TemperaturesHistoryView), 
            typeof(LoadSwitchConsumptionView), 
            typeof(HomeConsumptionGraphView)
    
        };
    
        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
        {
            foreach (var screenType in SupportingLandscapeScreenTypes)
            {
                if (GetType() == screenType)
                    return UIInterfaceOrientationMask.Portrait | UIInterfaceOrientationMask.LandscapeLeft | UIInterfaceOrientationMask.LandscapeRight;
            }
            return UIInterfaceOrientationMask.Portrait;
        }
        public override UIInterfaceOrientation PreferredInterfaceOrientationForPresentation()
        {
            return UIInterfaceOrientation.Portrait;
        }
    
    }
    public class MyEnergateAppNavigationController:UINavigationController
    {
        public MyEnergateAppNavigationController(UIViewController rootController)
            :base (rootController)
        {
        }
        public override bool ShouldAutorotate()
        {
            return true;
        }
        //[Obsolete ("Deprecated in iOS6. Replace it with both GetSupportedInterfaceOrientations and PreferredInterfaceOrientationForPresentation")]
        //public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
        //{
        //    return TopViewController.ShouldAutorotateToInterfaceOrientation(toInterfaceOrientation);
        //}
        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
        {
            return TopViewController.GetSupportedInterfaceOrientations();
        }
        public override UIInterfaceOrientation PreferredInterfaceOrientationForPresentation()
        {
            return TopViewController.PreferredInterfaceOrientationForPresentation();
        }
    }
