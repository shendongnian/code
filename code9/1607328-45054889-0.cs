            string request;
            using (var memoryStream = new MemoryStream())
            {
                var requestStream = await context.Request.Content.ReadAsStreamAsync();
                requestStream.Position = 0;
                requestStream.CopyTo(memoryStream);
                memoryStream.Position = 0;
                using (StreamReader streamReader = new StreamReader(memoryStream))
                {
                    request = streamReader.ReadToEnd();
                }
            }
            Debug.WriteLine(request)
