    public async Task ImportFile(IFormFile file)
        {
            RestClient restClient = new RestClient(_queryBulder.BuildImportFileRequest());
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StreamContent(file.OpenReadStream())
                {
                    Headers =
                    {
                        ContentLength = file.Length,
                        ContentType = new MediaTypeHeaderValue(file.ContentType)
                    }
                }, "File", "FileImport");
                var response = await restClient.Post<IFormFile>(content);
            }
        }
