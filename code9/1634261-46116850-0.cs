    public class SendFile
    {
        public SendFile(Uri uri) { /* some code here */ }
        public SendFile(string id) { /* some code here */ }
        public static SendFile Create(string url, string fallbackId = null)
        {
            return string.IsNullOrEmpty(url)
                ? new SendFile(fallbackId)
                : new SendFile(new Uri(url));
        }
    }
