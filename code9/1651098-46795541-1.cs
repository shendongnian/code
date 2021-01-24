    public RNGCryptoServiceProvider()
      : this((CspParameters) null)
    {
    }
    [SecuritySafeCritical]
    public RNGCryptoServiceProvider(CspParameters cspParams)
    {
      if (cspParams != null)
      {
        this.m_safeProvHandle = Utils.AcquireProvHandle(cspParams);
        this.m_ownsHandle = true;
      }
      else
      {
        // we are interested in this path
        this.m_safeProvHandle = Utils.StaticProvHandle;
        this.m_ownsHandle = false;
      }
    }
