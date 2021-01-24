        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(IFormFile file)
        {
            var filePath = Path.GetTempFileName();
            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
            {
                await file.CopyToAsync(stream);
                stream.Position = 0;
                using (var formDataContent = new MultipartFormDataContent())
                {
                    using (var httpClient = new HttpClient())
                    {
                        formDataContent.Add(CreateFileContent(stream, "myfile.test", "application/octet-stream"));
                        
                        var response = await httpClient.PostAsync(
                            "http://localhost:56595/home/upload",
                            formDataContent);
                        return Json(response);
                    }
                }
            }
        }
        internal static StreamContent CreateFileContent(Stream stream, string fileName, string contentType)
        {
            var fileContent = new StreamContent(stream);
            fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
            {
                Name = "\"file\"",
                FileName = "\"" + fileName + "\"",
            };
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
            return fileContent;
        }
