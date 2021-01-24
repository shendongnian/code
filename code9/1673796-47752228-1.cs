    public void OnUserInput( )
	{
		// DoSomething( );
        StartTimedUpdate( );
	}
	private void DoSomething( )
	{
		// and here we do it
	}
	DispatcherTimer m_timer = null;
	private void StartTimedUpdate()
	{
		if (m_timer == null)
		{
			m_timer = new System.Windows.Threading.DispatcherTimer();
			m_timer.Tick += TimedRefresh;
			m_timer.Interval = TimeSpan.FromMilliseconds(100);
			m_timer.Start();
		}
	}
	private void TimedRefresh(object sender, EventArgs e)
	{
		if (m_timer != null)
			m_timer.Stop();
		m_timer = null;
		DoSomething();
	}
