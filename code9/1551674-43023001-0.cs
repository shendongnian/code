     public class Class1
      {
        public async Task<Google.Apis.Drive.v3.Data.FileList> ReadFileList(string parentId, string pageToken, int pageSize)
        {
          // get the service somehow.
          var ds = new DriveService();
    
          var listRequest = ds.Files.List();
          listRequest.PageSize = pageSize;
          listRequest.Q = "mimeType='application/vnd.google-apps.folder' and ('" + parentId + "' in parents)";
          listRequest.Fields = "nextPageToken, files(id, name)";
          listRequest.PageToken = pageToken;
    
          // List files.
          return await listRequest.ExecuteAsync();
        }
      }
