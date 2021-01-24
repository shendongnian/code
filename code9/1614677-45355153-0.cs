    private WindowsUniversalScanners()
    {
        //Get our event for when the app resumes from suspended state
        Application.Current.Resuming += App_Resuming;
        StartScanner();
    }
    private async void App_Resuming(object sender, object e)
    {
        try
        {
            //When the app resumes from suspended state, the ClaimedScanner object will be disposed but NOT null. This means the only 
            //way to trap this is try to access a property in the object and catch an ObjectDisposedException. 
            var scannerStatus = ClaimedScanner.IsEnabled;
        }
        catch (ObjectDisposedException oe)
        {
            //Now we know we are in a stuck state, we can try to heal from it. First we destroy scanner object and set it to null.
            if (DestroyScanner())
            {
                //Finally we re-start the scanner
                await StartScanner();
            }
        }
    }
