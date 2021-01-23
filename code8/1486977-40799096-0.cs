    Response.Clear();
    Response.ClearHeaders();
    Response.ClearContent();
    Response.AddHeader("Content-Disposition", "attachment; filename=\"" + file.Name + "\"");
    Response.AddHeader("Content-Length", file.Length.ToString());
    Response.ContentType = your content type
    Response.Flush();
    Response.TransmitFile(file.FullName);
    Response.End();
