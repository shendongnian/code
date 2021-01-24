    public class DownloadFileResult : IStreamWriterAsync, IHasOptions
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
    
        public async Task WriteToAsync(Stream responseStream, CancellationToken token)
        {
            if (_stream == null) { 
                return;
    	    }
            await _stream.CopyToAsync(responseStream);
            responseStream.Flush();
        }
    }
