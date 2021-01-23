    public class FilesListOptionalParms
        {
            /// The source of files to list.
            public string Corpus { get; set; }  
            /// A comma-separated list of sort keys. Valid keys are 'createdTime', 'folder', 'modifiedByMeTime', 'modifiedTime', 'name', 'quotaBytesUsed', 'recency', 'sharedWithMeTime', 'starred', and 'viewedByMeTime'. Each key sorts ascending by default, but may be reversed with the 'desc' modifier. Example usage: ?orderBy=folder,modifiedTime desc,name. Please note that there is a current limitation for users with approximately one million files in which the requested sort order is ignored.
            public string OrderBy { get; set; }  
            /// The maximum number of files to return per page.
            public int PageSize { get; set; }  
            /// The token for continuing a previous list request on the next page. This should be set to the value of 'nextPageToken' from the previous response.
            public string PageToken { get; set; }  
            /// A query for filtering the file results. See the "Search for Files" guide for supported syntax.
            public string Q { get; set; }  
            /// A comma-separated list of spaces to query within the corpus. Supported values are 'drive', 'appDataFolder' and 'photos'.
            public string Spaces { get; set; }  
        
        }
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
