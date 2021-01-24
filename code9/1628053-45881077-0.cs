    public interface ICloubBlobClient {
        //...expose only the functionality I need
    }
    public class CloubBlobClientWrapper : ICloubBlobClient {
        private readonly CloubBlobClient client;
        public CloubBlobClientWrapper(CloubBlobClient client) {
            this.client = client;
        }
        //...implement interface wrapping
    }
