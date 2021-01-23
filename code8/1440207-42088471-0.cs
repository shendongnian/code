    protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
	
			//====================================
			View decorView = Window.DecorView;
			var uiOptions = (int)decorView.SystemUiVisibility;
			var newUiOptions = (int)uiOptions;
			newUiOptions |= (int)SystemUiFlags.LowProfile;
			newUiOptions |= (int)SystemUiFlags.Fullscreen;
			newUiOptions |= (int)SystemUiFlags.HideNavigation;
			newUiOptions |= (int)SystemUiFlags.ImmersiveSticky;
			decorView.SystemUiVisibility = (StatusBarVisibility)newUiOptions;
			//====================================
			global::Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new Pages.App());
		}
