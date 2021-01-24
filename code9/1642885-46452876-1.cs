    public class FileController : Controller
        {
            [HttpPost]
            public async Task<IActionResult> Post([FromBody] MultipartFormDataContent content)
            {
             MultipartMemoryStreamProvider provider = new MultipartMemoryStreamProvider();
            FilePart part = null;
             // access the content here 
             await content.ReadAsMultipartAsync(provider);
            // rest of the code
           }
       }
