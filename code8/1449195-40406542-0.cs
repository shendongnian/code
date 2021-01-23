            HttpRequestMessage request = this.Request;
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            var parts = await request.Content.ReadAsMultipartAsync();
            Stream inputStream = null;
            string fname = null;
            foreach (var part in parts.Contents)
            {
                string dispoName = part.Headers.ContentDisposition.Name;
                if (dispoName.Equals("\"inputFile\""))
                {
                    fname = part.Headers.ContentDisposition.FileName;
                    inputStream = await part.ReadAsStreamAsync();
                }
            }
            if (inputStream == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
