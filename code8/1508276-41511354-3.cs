    [Route("api/[controller]")]
    public class DocumentController : Controller {
        // POST api/document
        [HttpPost]
        public async Task<IActionResult> Post(FormData data) {
            if(data!= null && ModelState.IsValid) {
                client.BaseAddress = new Uri("http://example.com:8000");
                client.DefaultRequestHeaders.Accept.Clear();
    
                var multiContent = new MultipartFormDataContent();
                
                var file = data.fileToUpload;
                if(file != null) {
                    var fileStreamContent = new StreamContent(file.OpenReadStream());
                    multiContent.Add(fileStreamContent, "fileToUpload", file.FileName);
                }
    
                multiContent.Add(new StringContent(model.id.ToString()), "id");
    
                var response = await client.PostAsync("/document/upload", multiContent);
                if (response.IsSuccessStatusCode) {
                   var retValue = await response.Content.ReadAsAsync<DocumentUploadResult>();
                   return Ok(reyValue);
                }
            }
            //if we get this far something Failed.
            return BadRequest();
        }        
    }
