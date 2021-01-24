       private static readonly object _syncRoot = new object();
    
       protected void qrDetectado(object sender, EventArgs e)
       {
    		lock(_syncRoot)
            {
                // Do stuff
            }
       }
