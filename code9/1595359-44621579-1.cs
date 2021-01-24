    public class BOM : IBOM
        {
          public Stream GetData()
            {
    
             
                string jsCode = "jsonpCallback" + "({\Test:\"" + fileNames +   "\"});";
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/javascript";
                return new MemoryStream(Encoding.UTF8.GetBytes(jsCode));
    
            }
