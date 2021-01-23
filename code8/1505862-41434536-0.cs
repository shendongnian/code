    protected override void Dispose(bool disposing)
            {
                if (disposed)
                    return;
    
                if (disposing)
                {
                    if (components != null)
                    {
                        components.Dispose();
                    }
    
                    // Dispose stuff here
                    TheUI.OnProgressUpdate -= FPProgUpdate;
    
                }
    
                disposed = true;
                base.Dispose(disposing);
            }
