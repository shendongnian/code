    protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
	        global::Xamarin.Forms.Forms.Init(this, bundle);
			//====================================
			int uiOptions = (int)Window.DecorView.SystemUiVisibility;
			uiOptions |= (int)SystemUiFlags.LowProfile;
			uiOptions |= (int)SystemUiFlags.Fullscreen;
			uiOptions |= (int)SystemUiFlags.HideNavigation;
			uiOptions |= (int)SystemUiFlags.ImmersiveSticky;
			Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
			//====================================
			
			LoadApplication(new Pages.App());
		}
