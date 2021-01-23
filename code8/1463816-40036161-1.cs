     public IHttpActionResult GetStream()
     {
        MemoryStream myMemoryStream = new MemoryStream();
        var sr = new System.IO.StreamReader(myMemoryStream);
        string myStr = sr.ReadToEnd();
        return Ok(myStr);          
     }
