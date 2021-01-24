    protected override void OnExit(ExitEventArgs e)
		{
			base.OnExit(e);
			this.DispatcherUnhandledException -= new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
		}
