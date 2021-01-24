        /// <summary>
        /// Lists or searches files. 
        /// Documentation https://developers.google.com/drive/v3/reference/files/list
        /// Generation Note: This does not always build correctly.  Google needs to standardize things I need to figure out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Drive service. </param>
        /// <param name="optional">The optional parameters. </param>        
        /// <returns>FileListResponse</returns>
        public static Google.Apis.Drive.v3.Data.FileList ListAll(DriveService service, FilesListOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                // Building the initial request.
                var request = service.Files.List();
                // Applying optional parameters to the request.                
                request = (FilesResource.ListRequest)SampleHelpers.ApplyOptionalParms(request, optional);
                var pageStreamer = new Google.Apis.Requests.PageStreamer<Google.Apis.Drive.v3.Data.File, FilesResource.ListRequest, Google.Apis.Drive.v3.Data.FileList, string>(
                                                   (req, token) => request.PageToken = token,
                                                   response => response.NextPageToken,
                                                   response => response.Files);
                var allFiles = new Google.Apis.Drive.v3.Data.FileList();
                allFiles.Files = new List<Google.Apis.Drive.v3.Data.File>();
                foreach (var result in pageStreamer.Fetch(request))
                {                    
                    allFiles.Files.Add(result);
                }
                return allFiles;
            }
            catch (Exception Ex)
            {
                throw new Exception("Request Files.List failed.", Ex);
            }
        }
