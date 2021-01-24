    class UploadVideo
    {
        public event EventHandler<string> StatusTextChanged;
        void videosInsertRequest_ResponseReceived(Video video)
        {
            StatusTextChanged?.Invoke(this, $"Video id '{video.Id}' was successfully uploaded.");
        }
    }
