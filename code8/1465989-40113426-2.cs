    //create an empty byte array
    byte[] bin;
    
    //'using' ensures the MemoryStream will be disposed correctly
    using (MemoryStream stream = new MemoryStream())
    {
        //save the pdf to the stream
        document.Save(stream, false);
        //fill the byte array with the pdf bytes from stream
        bin = stream.ToArray();
    }
    
    //clear the buffer stream
    Response.ClearHeaders();
    Response.Clear();
    Response.Buffer = true;
    
    //set the correct ContentType
    Response.ContentType = "application/pdf";
    
    //set the correct length of the string being send
    Response.AddHeader("content-length", bin.Length.ToString());
    
    //set the filename for the pdf
    Response.AddHeader("content-disposition", "attachment; filename=\"MyCertificate.pdf\"");
    
    //send the byte array to the browser
    Response.OutputStream.Write(bin, 0, bin.Length);
    
    //cleanup
    Response.Flush();
    Response.Close();
