    public void ProcessRequest(HttpContext context)
    {
        //create a new byte array
        byte[] bin = new byte[0];
        //get the item from a datatable
        bin = (byte[])dt.Rows[0]["img"];
        //read the image in an `Image` and then get the bytes in a memorystream
        Image img = Image.FromFile(context.Server.MapPath("test.jpg"));
        using (var ms = new MemoryStream())
        {
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            bin = ms.ToArray();
        }
    
        //or as one-liner
        bin = File.ReadAllBytes(context.Server.MapPath("test.jpg"));
        //clear the buffer stream
        context.Response.ClearHeaders();
        context.Response.Clear();
        context.Response.Buffer = true;
        //set the correct ContentType
        context.Response.ContentType = "image/jpeg";
        //set the filename for the image
        context.Response.AddHeader("Content-Disposition", "attachment; filename=\"myImage.jpg\"");
        //set the correct length of the string being send
        context.Response.AddHeader("content-Length", bin.Length.ToString());
        //send the byte array to the browser
        context.Response.OutputStream.Write(bin, 0, bin.Length);
        //cleanup
        context.Response.Flush();
        context.ApplicationInstance.CompleteRequest();
    }
