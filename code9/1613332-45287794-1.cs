    public class NoLocalFileRequest:WebRequest
    {
        // return an instance of our custom webResponse
        public override WebResponse GetResponse()
        {
            return new NoLocalFileResponse();
        }
    }
    
