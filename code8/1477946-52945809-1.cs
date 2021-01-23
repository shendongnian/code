    if (this._twain32.Capabilities.Duplex.IsSupported(TwQC.GetCurrent) && this._twain32.Capabilities.Duplex.GetCurrent() != TwDX.None)
                    {
                        if (this._twain32.Capabilities.FeederEnabled.IsSupported(TwQC.Set))
                        {
                            this._twain32.Capabilities.FeederEnabled.Set(true);
    
                            if (this._twain32.Capabilities.DuplexEnabled.IsSupported(TwQC.Set))
                            {
                                this._twain32.Capabilities.DuplexEnabled.Set(true);
                            }
                            this._twain32.Capabilities.XferCount.Set(-1);
                        }
                    }
