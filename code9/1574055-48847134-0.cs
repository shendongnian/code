    public class HomeController : Controller
    {
        public async Task<FileStreamResult> Streaming(long RecordCount)
        {
            HttpClient Client;
            System.IO.Stream Stream;
            //This is the key thing
            Response.Buffer=false;
            Client = new HttpClient() { BaseAddress=new Uri("http://MyApi", };
            Stream = await Client.GetStreamAsync("api/Streaming?RecordCount="+RecordCount);
            return new FileStreamResult(Stream, "text/csv");
        }
    }
