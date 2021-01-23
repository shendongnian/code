    public void ProcessRequest(HttpContext context)
    {
        //create a new byte array
        byte[] bin = new byte[0];
    
        //get your data from the db
        while (rdr.Read())
        {
            bin = (byte[])rdr["img"];
        }
    
        //clear the buffer stream
        context.Response.ClearHeaders();
        context.Response.Clear();
        context.Response.Buffer = true;
    
        //set the correct ContentType
        context.Response.ContentType = "image/jpeg";
    
        //set the filename for the pdf
        context.Response.AddHeader("Content-Disposition", "attachment; filename=\"myImage.jpg\"");
    
        //set the correct length of the string being send
        context.Response.AddHeader("content-Length", bin.Length.ToString());
    
        //send the byte array to the browser
        context.Response.OutputStream.Write(bin, 0, bin.Length);
    
        //cleanup
        context.Response.Flush();
        context.ApplicationInstance.CompleteRequest();
    }
