    async Task<string> DoCamCardAsync()
        {
            var cli = new HttpClient();
            cli.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
 
            // Why use a custom boundary for multipart/form-data?
            // .NET sticks the thing in quotes in the header; the CamCard server goes nuts for the quotes (takes them literally); while the
            // actual boundary is delineated in the request by the unquoted boundary.
            var boundary = Guid.NewGuid().ToString();
            using (var form = new MultipartFormDataContent(boundary))
            {
                form.Headers.Remove("Content-Type");
                form.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data; boundary=" + boundary);
                byte[] cardBytes = File.ReadAllBytes(@"file path here, or use stream instead");
                var fileContent = new ByteArrayContent(cardBytes);
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name="\"upfile\"",
                    FileName = "\"card_m.jpg\""
                };
                fileContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("image/jpeg");
                form.Add(fileContent);
                var sURl = "https://bcr1.intsig.net/BCRService/BCR_VCF2?user=[your username here]&pass=[your key here]&json=1&lang=1";
                var response = await cli.PostAsync(sURl, form);
                return await response.Content.ReadAsStringAsync();
            }
