	    private AppCallbacks m_AppCallbacks;
	    private UnityBridge _unityBridge;
	    public App()
		{
			m_AppCallbacks = new AppCallbacks();
           
			// Allow clients of this class to append their own callbacks.
			AddAppCallbacks(m_AppCallbacks);
		}
		virtual protected void AddAppCallbacks(AppCallbacks appCallbacks)
		{
		    _unityBridge = UnityBridge.Create();
            
		}
