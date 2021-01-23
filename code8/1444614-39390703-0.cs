    [HttpGet]
    [Route("file/{fileId}")]
    public HttpResponseMessage GetPdfInvoiceFile(string fileId)
            {
                var response = Request.CreateResponse();
                //read from database 
                var fileByteArray= ReturnFile(fileId);
                if (fileByteArray == null) throw new Exception("No document found");
                using (MemoryStream ms = new MemoryStream())
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Content = new StreamContent(new MemoryStream(fileByteArray));
                    response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = fileId+ ".docx"
                    };
                    response.Content.Headers.ContentType =
                        new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.wordprocessingml.document");
                    response.Headers.Add("Content-Transfer-Encoding", "binary");
                    response.Content.Headers.ContentLength = fileByteArray.Length;
                    return response;
                }
            }
        }
