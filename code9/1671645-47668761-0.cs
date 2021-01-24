    using System.Net.Http;
    using System.IO;
    
    public async Task<HttpResponseMessage> GetPDFFromCompanyWebsite()
    {
    string currentDirectory = System.Web.Hosting.HostingEnvironment.MapPath("~");
    string filePath = Path.Combine(currentDirectory, "App_Data", "someDocument.pdf");
    
    using(HttpClient client = new HttpClient())
    {
        HttpResponseMessage msg = await client.GetAsync($"http://example/sites/index.php/2011-10-30-12-29-04/finish/11/1234");
    
        if(msg.IsSuccessStatusCode)
        {
         using(var file = File.Create(filePath))
         { 
           // create a new file to write to
           var contentStream = await msg.Content.ReadAsStreamAsync(); // get the actual content stream
           await contentStream.CopyToAsync(file); // copy that stream to the file stream
           await file.FlushAsync(); // flush back to disk before disposing
         }
       }
      return msg;
    } }
