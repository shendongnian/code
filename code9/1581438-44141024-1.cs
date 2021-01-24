    public static class MyExtensions
    {
        public static ContentDispositionHeaderValue MyGetContentDisposition(this HttpContent httpContent)
        {
            if (httpContent is MultipartContent)
                return ((MultipartContent) httpContent).FirstOrDefault(c => c.Headers.ContentDisposition != null)?.Headers.ContentDisposition;
            return httpContent.Headers.ContentDisposition;
        }
    }
