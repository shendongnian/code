        public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
        {
            // For form data, Content-Disposition header is a requirement
            ContentDispositionHeaderValue contentDisposition = headers.ContentDisposition;
            if (contentDisposition != null && !String.IsNullOrEmpty(contentDisposition.FileName))
            {
                // We won't post process files as form data
                _isFormData.Add(false);
                //create unique identifier for this file upload
                var identifier = Guid.NewGuid();
                var fileName = contentDisposition.FileName;
                var boundaryObj = parent.Headers.ContentType.Parameters.SingleOrDefault(a => a.Name == "boundary");
                var boundary = (boundaryObj != null) ? boundaryObj.Value : "";
                if (fileName.Contains("\\"))
                {
                    fileName = fileName.Substring(fileName.LastIndexOf("\\") + 1).Replace("\"", "");
                }
                //write parent container for the file chunks that are being stored
                WriteLargeFileContainer(fileName, identifier, headers.ContentType.MediaType, boundary);
                //create an instance of the custom stream that will write the chunks to the database
                var stream = new CustomSqlStream();
                stream.Filename = fileName;
                stream.FullFilename = contentDisposition.FileName.Replace("\"", "");
                stream.Identifier = identifier.ToString();
                stream.ContentType = headers.ContentType.MediaType;
                stream.Boundary = (!string.IsNullOrEmpty(boundary)) ? boundary : "";
                return stream;
            }
            else
            {
                // We will post process this as form data
                _isFormData.Add(true);
                // If no filename parameter was found in the Content-Disposition header then return a memory stream.
                return new MemoryStream();
            }
        }
