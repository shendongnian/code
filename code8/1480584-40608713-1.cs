    internal class MyBootstrapper
    {
        // [...]
		protected override void InitializeModules()
		{
			Task.Run( () =>	base.InitializeModules() );
		}
    }
