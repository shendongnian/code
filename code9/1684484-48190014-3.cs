    public class Download {
        private static readonly HttpClient Client = new HttpClient();
        private readonly string _fileUrl;
        private readonly CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private Task _copyTask;
        private Stream _responseStream;
        private Stream _fileStream;
        public Download(string fileUrl) {
            _fileUrl = fileUrl;
        }
        public async Task Start(string saveTo) {
            var response = await Client.GetAsync(_fileUrl, HttpCompletionOption.ResponseHeadersRead);
            _responseStream = await response.Content.ReadAsStreamAsync();
            _fileStream = File.Create(saveTo);
            _copyTask = _responseStream.CopyToAsync(_fileStream, 81920, _tokenSource.Token);
        }
        public void Cancel() {
            _tokenSource.Cancel();
            _responseStream.Dispose();
            _fileStream.Dispose();
        }
    }
