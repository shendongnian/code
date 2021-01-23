    protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
	
			//====================================
			int newUiOptions = (int)Window.DecorView.SystemUiVisibility;
			newUiOptions |= (int)SystemUiFlags.LowProfile;
			newUiOptions |= (int)SystemUiFlags.Fullscreen;
			newUiOptions |= (int)SystemUiFlags.HideNavigation;
			newUiOptions |= (int)SystemUiFlags.ImmersiveSticky;
			Window.DecorView.SystemUiVisibility = (StatusBarVisibility)newUiOptions;
			//====================================
			global::Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new Pages.App());
		}
