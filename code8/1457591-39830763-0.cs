    // create a MemoryStream to act as a buffer for some unspecified data
    using (var stream = new MemoryStream())
    {
        // obtain the http-context (not sure this is a good way to do it)
        var context = (System.Web.HttpContextBase)Request.Properties["MS_HttpContext"];
        // reset the context's input stream to the start
        context.Request.InputStream.Seek(0, SeekOrigin.Begin);
        // copy the input stream to the buffer we allocated before
        context.Request.InputStream.CopyTo(stream);
        // create an array from the buffer, then use that array to
        // create  a string via the UTF8 encoding
        strContent = Encoding.UTF8.GetString(stream.ToArray());
        // write the number of characters in the string to the log
        AppLog.Write("Request content length: " + strContent.Length);
    }
