    [OperationContract]
    [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "UploadImage/{fileName}")]
    string UploadImage(string fileName);
    public string UploadImage(string fileName)
        {
            try
            {
                HttpPostedFile file = HttpContext.Current.Request.Files["post"];
                if (file == null)
                    return null;
                string targetFilePath = WebConfigurationManager.AppSettings["FilePath"] + fileName;
                file.SaveAs(targetFilePath);
                return "succ   " + file.FileName.ToString(); ;
            }
            catch (Exception ex)
            {
                return ex.Message + " - " + ex.InnerException;
            }
        }
