    StringBuilder sb = new StringBuilder();
    sb.Add("Some text");
   
    // Clear anything the page has begun to buffer. We don't want that.
    Response.ClearHeaders();
    Response.ClearContent();
    // Write something to the Response.OutputStream here
    Response.ContentType = "text/plain";
    Response.CharSet = "utf-8";
    Response.OutputStream.Write(System.Text.Encoding.UTF8.GetBytes(sb.ToString()));
    
    // Send to the client immediately.
    Response.Flush();
    // Prevent any more being added by ASP.Net
    Response.SuppressContent = true;
