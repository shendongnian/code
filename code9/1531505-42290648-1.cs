    //To check if device is allowed to rotate
    private bool _allowLandscape;
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        private bool _allowLandscape;
    
        protected override void OnCreate(Bundle bundle)
        {
            switch (Device.Idiom)
            {
                case TargetIdiom.Phone:
                    RequestedOrientation = ScreenOrientation.Portrait;
                    break;
                case TargetIdiom.Tablet:
                    RequestedOrientation = ScreenOrientation.Landscape;
                    break;
            }
    
            base.OnCreate(bundle);
    
            //Setup additional stuff that you need
    
            //Calls from the view that should rotate
            MessagingCenter.Subscribe<GraphicsView>(this, "graphic", sender =>
            {
                _allowLandscape = true;
                OnConfigurationChanged(new Configuration());
            });
    
            //When the page is closed this is called
            MessagingCenter.Subscribe<GraphicsView>(this, "return", sender =>
            {
                _allowLandscape = false;
                OnConfigurationChanged(new Configuration());
            });
    
            LoadApplication(new App());
        }
    
        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
        
            switch (newConfig.Orientation)
            {
                case Orientation.Landscape:
                    switch (Device.Idiom)
                    {
                        case TargetIdiom.Phone:
                            if (!_allowLandscape)
                            {
                                LockRotation(Orientation.Portrait);
                            }
                            break;
                        case TargetIdiom.Tablet:
                            LockRotation(Orientation.Landscape);
                            break;
                    }
                    break;
                case Orientation.Portrait:
                    switch (Device.Idiom)
                    {
                        case TargetIdiom.Phone:
                            if (!_allowLandscape)
                            {
                                LockRotation(Orientation.Portrait);
                            }
                            break;
                        case TargetIdiom.Tablet:
                            LockRotation(Orientation.Landscape);
                            break;
                    }
                    break;
                case Orientation.Undefined:
                    if (Device.Idiom == TargetIdiom.Phone && _allowLandscape)
                    {
                        LockRotation(Orientation.Landscape);
                    }
                    else if (Device.Idiom == TargetIdiom.Phone && !_allowLandscape)
                    {
                        LockRotation(Orientation.Portrait);
                    }
                    break;
            }
        }
        
        private void LockRotation(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.Portrait:
                    RequestedOrientation = ScreenOrientation.Portrait;
                    break;
                case Orientation.Landscape:
                    RequestedOrientation = ScreenOrientation.Landscape;
                    break;
			}
		}
	}
    
