    else
    {
        var filePath = HttpContext.Current.Server.MapPath("~/Content/Banner/" + postedFile.FileName + extension);
                            postedFile.SaveAs(filePath);
        return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.Created,
                    Content = new StringContent(filePath, Encoding.UTF8, "application/json")
                };
    }
