    public class DownloadService {
        public string DOWNLOAD_FOLDER {
            get => "C:\\tmp";
        }
        public static readonly ConcurrentDictionary<string, Download> Downloads = new ConcurrentDictionary<string, Download>();
        public async Task<string> StartDownload(string fileUrl) {
            var downloadId = Guid.NewGuid().ToString("N");
            Downloads[downloadId] = new Download(fileUrl);
            await Downloads[downloadId].Start(Path.Combine(DOWNLOAD_FOLDER, downloadId));
            return downloadId;
        }
        public void CancelDownload(string downloadId) {
            if (Downloads.TryRemove(downloadId, out var download)) {
                download.Cancel();
            }
        }
