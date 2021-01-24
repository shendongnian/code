        public static async Task<Stream> GetFile(string FileId)
        {
            try
            {
                TransferUtilityOpenStreamRequest request = new TransferUtilityOpenStreamRequest();
                request.BucketName = Config.S3BucketName;
                request.Key = FileId;
                return await S3Utility.OpenStreamAsync(request);
            }
            catch (Exception e)
            {
                if (Globals.Config.IsDebug)
                    Console.WriteLine("[S3] " + e.ToString());
                return null;
            }
        }
