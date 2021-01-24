    class UploadVideo
    {
        private readonly IProgress<string> _progress;
        public UploadVideo(IProgress<string> progress)
        {
            _progress = progress;
        }
        void videosInsertRequest_ResponseReceived(Video video)
        {
            _progress.Report($"Video id '{video.Id}' was successfully uploaded.");
        }
    }
