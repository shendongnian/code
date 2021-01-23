    [WebMethod]
    public static string LoadFileContents(string fileName)
    {
    	if (!Page.IsPostBack)
    	{
           string fileContents = string.Empty;
           string path = HostingEnvironment.ApplicationPhysicalPath + "\\Files\\" + fileName;
        
           if (File.Exists(path))
           {
              fileContents = File.ReadAllText(path);
           }
           return fileContents;
    	}
    }
