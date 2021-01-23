    public class SomeClassInClassLibrary
    {
        private readonly IRequestInformation requestInfo;
        public SomeClassInClassLibrary(IRequestInfomation requestInfo) 
        {
            // Don't forget null checks
            this.requestInfo = requestInfo;
            // access it
            var host = requestInfo.Host;
        }
    }
