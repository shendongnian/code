    internal class MyBootstrapper
    {
        // [...]
		protected override void InitializeModules()
		{
			var splashScreen = new SplashScreen( "myLogo.png" );
			splashScreen.Show( false );
			try
			{
				base.InitializeModules();
			}
			finally
			{
				splashScreen.Close( TimeSpan.Zero );
			}
		}
    }
