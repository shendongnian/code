    public class NoLocalFileResponse : WebResponse {
    
        static byte[] responseBytes = Encoding.ASCII.GetBytes("NO!");
        public override long ContentLength
        {
            get {
                return responseBytes.Length;
            }
            set {              
                // whatever
            }
        }
    
        public override Stream GetResponseStream()
        {
            // what you want to return goes here
            return new MemoryStream(responseBytes);
        }
    }
