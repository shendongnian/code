    [Route("api/[controller]")]
    public class DocumentController : Controller {
        // POST api/document
        [HttpPost]
        public async Task<IActionResult> Post(FormData data) {
            client.BaseAddress = new Uri("http://example.com:8000");
            client.DefaultRequestHeaders.Accept.Clear();
            var multiContent = new MultipartFormDataContent();
            
            var file = model.fileToUpload;
            if(file != null) {
                var fileContent = new byte[file.Length];
                using (var reader = file.OpenReadStream()) {
                    await reader.ReadAsync(fileContent, 0, (int)file.Length);
                }
                var bytes = new ByteArrayContent(fileContent);
                multiContent.Add(bytes, "fileToUpload", file.FileName);
            }
            multiContent.Add(new StringContent(model.id.ToString()), "id");
            var response = await client.PostAsync("/document/upload", multiContent);
            if (response.IsSuccessStatusCode) {
               var retValue = await response.Content.ReadAsAsync<DocumentUploadResult>();
               return Ok(reyValue);
            }
            //if we get this far something Failed.
            return InternalServerError();
        }
    }
