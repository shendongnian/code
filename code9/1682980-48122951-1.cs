    @{
    
        if (IsPost)
        {
            var payload = "";
            using (var reader = new StreamReader(Request.InputStream))
            {
                payload = reader.ReadToEnd();
            }
    
            Response.AddHeader("Content-Type", "text/text");
            Response.Write(payload);
    
        }
    
    }
