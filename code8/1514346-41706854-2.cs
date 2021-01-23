        public class CompressedContent : HttpContent
    {
        private HttpContent originalContent;
        protected override bool TryComputeLength(out long length)
        {
            length = -1;
            return false;
        }
        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            Stream editedStream = null;
            if (encodingType == "gzip")
            {
                editedStream = new GZipStream(stream, CompressionMode.Compress, leaveOpen: true);
            }
            else if (encodingType == "deflate")
            {
                editedStream = new DeflateStream(stream, CompressionMode.Compress, leaveOpen: true);
            }
            return originalContent.CopyToAsync(editedStream).ContinueWith(tsk =>
            {
                if (editedStream != null)
                {
                    editedStream.Dispose();
                }
            });
        }
    }
