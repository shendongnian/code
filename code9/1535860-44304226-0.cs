        [ValidateMimeMultipartContentFilter]
        [HttpPost, Route("softwarepackage")]
        public Task<SoftwarePackageModel> UploadSingleFile()
        {
            var streamProvider = new MultipartFormDataStreamProvider(ServerUploadFolder);
            var task = Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith<SoftwarePackageModel>(t =>
            {
                var firstFile = streamProvider.FileData.FirstOrDefault();
                if (firstFile != null)
                {
                    // Do something with firstFile.LocalFileName
                }
                return new SoftwarePackageModel
                {
                    
                };
            });
            return task;
        }
