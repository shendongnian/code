    // Given you have a custom EventArgs class ...
    // Define an event on which clients can register their handlers
    public event EventHandler<BCDetectedEventArgs> BarcodeDetected;
    // infoObject should probably be of the type what `scan` is.
    protected virtual void OnBarcodeDetected( object infoObject ) 
    {
        // Check if there is at least one handler registered
        var handler = BarcodeDetected;
        if( handler != null )
        {
             
             handler(this, new BCDetectedEventArgs(infoObject));
        }
    }
    void IScanSuccessCallback.barcodeDetected(MWResult result)
    {
       if (result != null)
       {
           try
           {
               var scan = Element as BarcodeScannerModal;
               if (scan == null)
                  return;
               else
                  OnBarcodeDetected( scan );
           }
           catch (Exception ex)
           {
               System.Diagnostics.Debug.WriteLine(ex.Message);
           }
       }
    }
