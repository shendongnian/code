        public class BlobHandler : IHttpHandler, IReadOnlySessionState
        {    
         public void ProcessRequest(HttpContext context)
         {
            var request = context.Request;
            var response = context.Response;
            var path = request.Url.AbsolutePath;
                            
            // helper method - get a blob instance, if it doesn't exist return null
            var blob = CloudStorage.GetBlob(Constants.StoragePrivateContainer, path);
            if (blob == null)
                throw new HttpException(404, "Blob not found.");
            // custom auth
            if (!context.Request.IsAuthenticated)
                throw new HttpException(403, "Access denied.");
            var p = context.User as CustomPrincipal;
            if (p == null)
                throw new HttpException(403, "Access denied.");
            if (!p.IsInRole(Enums.Role.Downloader))
                throw new HttpException(403, "Access denied.");
            blob.DownloadToStream(context.Response.OutputStream);
                response.ContentType = blob.Properties.ContentType;
                response.Flush();            
        }
        public bool IsReusable => true;
       }
