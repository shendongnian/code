    public class ValuesController : ApiController {
        [HttpGet]
        public IHttpActionResult DownFile(string base64String) {
            if (!string.IsNullOrWhiteSpace(base64String)) {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new ByteArrayContent(imageBytes);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
                return ResponseMessage(response);
            }
            return BadRequest();
        }
    }
