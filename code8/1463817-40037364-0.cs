                        public HttpResponseMessage GetFile()
                        {
                            byte[] byteArray; 
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                // Do you processign here
                                byteArray = memoryStream.ToArray();
                            }
                            var response = new HttpResponseMessage(HttpStatusCode.OK);
                            response.Content = new ByteArrayContent(byteArray);
                            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                            //suppose its .xlsx file
                            response.Content.Headers.ContentDisposition.FileName = "Sample.xlsx";
                            return response;
                        }
