    using System.Web.Services;
    protected void Page_Load(object sender, EventArgs e)
    
    {
    
        if (!this.IsPostBack)
    
        {
    
            if (Request.InputStream.Length > 0)
    
            {
    
                using (StreamReader reader = new StreamReader(Request.InputStream))
    
                {
    
                    string hexString = Server.UrlEncode(reader.ReadToEnd());
    
                    string imageName = DateTime.Now.ToString("dd-MM-yy hh-mm-ss");
    
                    string imagePath = string.Format("~/Captures/{0}.png", imageName);
    
                    File.WriteAllBytes(Server.MapPath(imagePath), ConvertHexToBytes(hexString));
    
                    Session["CapturedImage"] = ResolveUrl(imagePath);
    
                }
    
            }
    
        }
    
    }
    
     
    
    private static byte[] ConvertHexToBytes(string hex)
    
    {
    
        byte[] bytes = new byte[hex.Length / 2];
    
        for (int i = 0; i < hex.Length; i += 2)
    
        {
    
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
    
        }
    
        return bytes;
    
    }
    
     
    
    [WebMethod(EnableSession = true)]
    
    public static string GetCapturedImage()
    
    {
    
        string url = HttpContext.Current.Session["CapturedImage"].ToString();
    
        HttpContext.Current.Session["CapturedImage"] = null;
    
        return url;
    
    }
