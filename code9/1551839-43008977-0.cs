    sing System;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
     
    namespace WebMvcTest.Controllers
    {
       [System.Web.Http.RoutePrefix("api/test")]
        public class FileUploadController : ApiController
        {
     
            [System.Web.Http.Route("files")]
            [System.Web.Http.HttpPost]
            [ValidateMimeMultipartContentFilter]
            public async Task<FileResult> UploadSingleFile()
            {
                var streamProvider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(streamProvider);
     
                string descriptionResult = string.Empty;
                var description =
                    streamProvider.Contents.AsEnumerable()
                        .FirstOrDefault(T => T.Headers.ContentDisposition.Name == "\"description\"");
                if (description != null)
                {
                    descriptionResult = await description.ReadAsStringAsync();
                }
     
                return new FileResult
                {
                    FileNames = streamProvider.Contents.AsEnumerable().Select(T => T.Headers.ContentDisposition.FileName).ToArray(),
                    Names = streamProvider.Contents.AsEnumerable().Select(T => T.Headers.ContentDisposition.FileName).ToArray(),
                    ContentTypes = streamProvider.Contents.AsEnumerable().Where(T => T.Headers.ContentType != null).Select(T => T.Headers.ContentType.MediaType).ToArray(),
                    Description = descriptionResult,
                    CreatedTimestamp = DateTime.UtcNow,
                    UpdatedTimestamp = DateTime.UtcNow,
                };
            }
        }
    }
