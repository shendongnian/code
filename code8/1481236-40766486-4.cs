    [HttpGet]
        [Route("file/{id}")]
        public async Task<HttpResponseMessage> GetFile(string id)
        {
            string mimeType = string.Empty;
            string filename = string.Empty;
            if (!string.IsNullOrEmpty(id))
            {
                //get the headers for the file being sent back to the user
                using (var myConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PortalBetaConnectionString"].ConnectionString))
                {
                    using (var myCmd = new SqlCommand("ReadLargeFileInfo", myConn))
                    {
                        myCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var pIdentifier = new SqlParameter("@Identifier", id);
                        myCmd.Parameters.Add(pIdentifier);
                        myConn.Open();
                        var dataReader = myCmd.ExecuteReader();
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                mimeType = dataReader.GetString(0);
                                filename = dataReader.GetString(1);
                            }
                        }
                    }
                }
                var result = new HttpResponseMessage()
                {
                    Content = new PushStreamContent(async (outputStream, httpContent, transportContext) =>
                    {
                        //pull the data back from the db and stream the data back to the user
                        await WriteDataChunksFromDBToStream(outputStream, httpContent, transportContext, id);
                    }),
                    StatusCode = HttpStatusCode.OK
                };
                
                result.Content.Headers.ContentType = new MediaTypeHeaderValue(mimeType);// "application/octet-stream");
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = filename };
                return result;
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
        private async Task WriteDataChunksFromDBToStream(Stream responseStream, HttpContent httpContent, TransportContext transportContext, string fileIdentifier)
        {
            // PushStreamContent requires the responseStream to be closed
            // for signaling it that you have finished writing the response.
            using (responseStream)
            {
                using (var myConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PortalBetaConnectionString"].ConnectionString))
                {
                    await myConn.OpenAsync();
                    //stored proc to pull the data back from the db
                    using (var myCmd = new SqlCommand("ReadAttachmentChunks", myConn))
                    {
                        myCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var fileName = new SqlParameter("@Identifier", fileIdentifier);
                        myCmd.Parameters.Add(fileName);
                        // The reader needs to be executed with the SequentialAccess behavior to enable network streaming
                        // Otherwise ReadAsync will buffer the entire BLOB into memory which can cause scalability issues or even OutOfMemoryExceptions
                        using (var reader = await myCmd.ExecuteReaderAsync(CommandBehavior.SequentialAccess))
                        {
                            while (await reader.ReadAsync())
                            {
                                //confirm the column that has the binary data of the file returned is not null
                                if (!(await reader.IsDBNullAsync(0)))
                                {
                                    //read the binary data of the file into a stream
                                    using (var data = reader.GetStream(0))
                                    {
                                        // Asynchronously copy the stream from the server to the response stream
                                        await data.CopyToAsync(responseStream);
                                        await data.FlushAsync();
                                    }
                                }
                            }
                        }
                    }
                }
            }// close response stream
        }
