    public class DownloadService {
        public string DOWNLOAD_FOLDER {
            get => "C:\\tmp";
        }
        public static Dictionary<string, CancellationTokenSource> DownloadTokens = new Dictionary<string, CancellationTokenSource>();
        public static Dictionary<string, Task> DownloadTasks = new Dictionary<string, Task>();
        private static HttpClient client = new HttpClient();
        public string StartDownload(string fileUrl) {
            var downloadId = Guid.NewGuid().ToString("N");
            DownloadTokens[downloadId] = new CancellationTokenSource();
            DownloadTasks[downloadId] = client.GetAsync(fileUrl, DownloadTokens[downloadId].Token).ContinueWith(
                requestTask => {
                    if (requestTask.IsCanceled) return;
                    // Get HTTP response from completed task.
                    var response = requestTask.Result;
                    // Check that response was successful or throw exception
                    response.EnsureSuccessStatusCode();
                    // Read response asynchronously and save to file
                    response.Content.ReadAsFileAsync(Path.Combine(DOWNLOAD_FOLDER, downloadId), true).ContinueWith(
                        readTask => {
                            var process = new Process {StartInfo = {FileName = downloadId}};
                            process.Start();
                        });
                });
            return downloadId;
        }
        public void CancelDownload(string downloadId) {
            if (DownloadTokens.TryGetValue(downloadId, out var token)) {
                token.Cancel();
                DownloadTokens.Remove(downloadId);
                DownloadTasks.Remove(downloadId);
            }
        }
    }
