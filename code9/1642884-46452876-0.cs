    public class FileController : Controller
        {
            [HttpPost]
            public async Task<IActionResult> Post([FromBody] ByteArrayContent fileContent)
            {
             MultipartMemoryStreamProvider provider = new MultipartMemoryStreamProvider();
            FilePart part = null;
             // access the content here 
             await fileContent.ReadAsMultipartAsync(provider);
            // rest of the code
           }
       }
