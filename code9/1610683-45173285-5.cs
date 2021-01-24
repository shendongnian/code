    public class ExampleApiController : ApiController {
        public async Task<IHttpActionResult> OutputTemplate() {
            IHttpActionResult result = BadRequest();
            var body = await Request.Content.ReadAsStreamAsync();                
            List<FileModel> files = DoSomething(body);
            if (files.Count > 1) {
                //compress the files.
                var archiveStream = files.Compress();
                var content = new StreamContent(archiveStream);
                var response = Request.CreateResponse(System.Net.HttpStatusCode.OK);
                response.Content = content;
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/zip");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") {
                    FileName = "fileexport.zip"
                };
                result = ResponseMessage(response);
            } else if (files.Count == 1) {
                //return the single file
                var fileName = files[0].FileName; //"fileexport.csv"
                var content = new ByteArrayContent(files[0].FileContent);
                var response = Request.CreateResponse(System.Net.HttpStatusCode.OK);
                response.Content = content;
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") {
                    FileName = fileName
                };
                result = ResponseMessage(response);
            }
            return result;
        }
        private List<FileModel> DoSomething(System.IO.Stream body) {
            //...TODO: implement file models
            throw new NotImplementedException();
        }
    }
