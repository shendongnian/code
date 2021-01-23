    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            try
            {
                if (this._hostContainerInternal != null)
                {
                    this._hostContainerInternal.Dispose();
                    this._hostContainerInternal = null;
                }
            }
            finally
            {
                try
                {
                    if (this._hwndSource != null)
                    {
                        this.DisposeHWndSource();
                    }
                }
                finally
                {
                    InputManager.Current.PostProcessInput -= 
                        new ProcessInputEventHandler(this.InputManager_PostProcessInput);
                    IDisposable child = this.Child as IDisposable;
                    if (child != null)
                    {
                        child.Dispose();
                    }
                }
            }
        }
        base.Dispose(disposing);
    }
