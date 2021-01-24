    #r "System.Configuration"
    #r "System.Data"
     
    using System.Net;
    using System.Net.Http.Headers;
    using System.Data.SqlClient;
    using System.IO;
     
    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
    {
        log.Info("C# HTTP trigger function processed a request.");
     
        // parse query parameter
        string productStr = req.GetQueryNameValuePairs()
            .FirstOrDefault(q => string.Compare(q.Key, "ProductId", true) == 0)
            .Value;
     
        int productId = int.Parse(productStr);
     
        string constr = "server=someserver.database.windows.net;database=databasename;user id=imageViererUser;Password=password";
     
        using (var con = new SqlConnection(constr))
        {
     
            await con.OpenAsync();
            log.Info("Connection Open.");
     
            var sql = @"        
            select ThumbnailPhoto
            from SalesLT.Product
            where ProductId = @productId
            ";
     
            var cmd = new SqlCommand(sql, con);
     
            cmd.Parameters.Add(new SqlParameter("@productId", productId));
     
            var buf = new MemoryStream();
     
            using (var rdr = await cmd.ExecuteReaderAsync(System.Data.CommandBehavior.SequentialAccess))
            {
                if (!rdr.Read())
                {
                    return req.CreateResponse(HttpStatusCode.NotFound);
                }
                var stream = rdr.GetStream(0);
     
                var resp = req.CreateResponse(HttpStatusCode.OK);
     
                await stream.CopyToAsync(buf);
                buf.Position = 0;
     
                log.Info($"Image Read {buf.Length} bytes");
                
                resp.Content = new StreamContent(buf);
                
                resp.Content.Headers.ContentType = new MediaTypeHeaderValue("image/gif");
     
                return resp;
                
            }
        }
     
        
    }
     
     
