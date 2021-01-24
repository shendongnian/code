    try
    {
        Response.Clear();
        Response.ContentType = "application/xml";
        Response.AddHeader("content-disposition", "attachment;filename=test.xml");
        Response.BufferOutput = true;
        Response.BinaryWrite(fileData);
        Response.Flush();
        //response.End();
        Response.Redirect("",false);
    }
    catch (Exception e)
    {
        throw new Exception(e);
    }
