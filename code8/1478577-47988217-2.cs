        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.RestrictRotation(true);
            // Perform any additional setup after loading the view, typically from a nib.
        }
        public override bool ShouldAutorotate()
        {
            return false;
        }
        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
        {
            return UIInterfaceOrientationMask.Portrait;
        }
        public override UIInterfaceOrientation PreferredInterfaceOrientationForPresentation()
        {
            return UIInterfaceOrientation.Portrait;
        }
        void RestrictRotation(bool restriction)
        {
            AppDelegate app = (AppDelegate)UIApplication.SharedApplication.Delegate;
            app.RestrictRotation = restriction;
        }
