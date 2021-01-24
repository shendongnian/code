     string jsonContent = "";
     using (var reader = new StreamReader(HttpContext.Current.Request.InputStream, System.Text.Encoding.UTF8, true, 4096, true))
         {    
          jsonContent= reader.ReadToEnd().ToString();
         }
     HttpContext.Current.Request.InputStream.Position = 0;
