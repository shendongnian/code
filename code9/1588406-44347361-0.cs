    internal class MyStreamListener : nsIStreamListener
    {
        public MyStreamListener(/*...*/) { }
        public void OnStartRequest(nsIRequest aRequest, nsISupports aContext)
        {
            // This will get called once, when the download "begins".
            // You can initialize your things here.
        }
        public void OnStopRequest(nsIRequest aRequest, nsISupports aContext, int aStatusCode)
        {
            // This will also get called once, when the download is 
            // complete or interrupted. You can perform the post-download 
            // actions here.
            if (aStatusCode != GeckoError.NS_OK) {
                // download interrupted
            }
            else {
                // download completed
            }
        }
        public void OnDataAvailable(nsIRequest aRequest, nsISupports aContext, nsIInputStream aInputStream, ulong aOffset, uint aCount)
        {
            // This gets called several times with small chunks of data. 
            // Do what you need with the stream. In my case, I read it 
            // in a small buffer, which then gets written to an output 
            // filestream (not shown).
            // The aOffset parameter is the sum of all previously received data.
            var lInput = InputStream.Create(aInputStream);
            byte[] lBuffer = new byte[aCount];
            lInput.Read(lBuffer, 0, (int)aCount);
        }
    }
    
