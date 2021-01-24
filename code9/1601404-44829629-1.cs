    public void ProcessRequest(HttpContext context)
    {
         var content = JsonConvert.SerializeObject<Example>(example);
         context.Response.Write(content);
         context.Response.End();
    } 
