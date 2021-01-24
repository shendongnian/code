     string jsonContent = "";
     using (var reader = new StreamReader(System.Web.HttpContext.Current.Request.InputStream, System.Text.Encoding.UTF8, true, 4096, true))
         {    
          jsonContent= reader.ReadToEnd().ToString();
         }
     System.Web.HttpContext.Current.Request.InputStream.Position = 0;
