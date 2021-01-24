    public class DownloadFileResult : IStreamWriter, IHasOptions
    {
        private readonly Stream _stream;
        public IDictionary<string, string> Options { get; }
    
        public DownloadFileResult(Stream responseStream, string mime, string filename)
        {
            _stream = responseStream;
    
            Options = new Dictionary<string, string>()
            {
                {"Content-Disposition", $"attachment; filename=\"{filename}\";"},
                {"Content-Type", mime}
            };
        }
    
        public void WriteTo(Stream responseStream)
        {
            if (_stream == null) { 
                return;
    	}
            _stream.WriteTo(responseStream);
            responseStream.Flush();
        }
    }
