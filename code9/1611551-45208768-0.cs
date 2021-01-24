    string thefile = SomeModelClass.SomeMethod(fileName, guid); // get full path to the file
    var cd = new System.Net.Mime.ContentDisposition
    {
        FileName = Path.GetFileName(thefile),
        Inline = false
    };
    Response.AppendHeader("Content-Disposition", cd.ToString());
    string fileext = Path.GetExtension(thefile);
    string mimeType = SomeMetodToMapextensionToMimeType(fileext); // You have to implement this by yourself
    return File(System.IO.File.ReadAllBytes(thefile), mime);
