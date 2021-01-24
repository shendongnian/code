    interface IStreamLoader
    {
        Task<Stream> GetStreamAsync( Uri uri );
    }
    interface IStreamRepository
    {
        Task<Stream> GetAsync( string id );
        Task PutAsync( string id, Stream stream );
        Task DeleteAsync( string id );
    }
    public class MyController
    {
        private readonly IStreamLoader _streamLoader;
        private readonly IStreamRepository _streamRepository;
        public MyController( IStreamLoader streamLoader, IStreamRepository streamRepository )
        {
            _streamLoader = streamLoader;
            _streamRepository = streamRepository;
        }
      
        [Route("api/[controller]/UploadFileToAzureStorage")]
        public async Task<IActionResult> GetFile([FromBody]PDF urlPdf)
        {
            Uri pdfUri = new Uri( urlPDF.urlPDF );
            using ( var pdfStream = await _streamLoader.GetStreamAsync( pdfUri ) )
            {
                await _streamRepository.PutAsync( "myblob", pdfStream );
            }
            return Ok();
        }
    }
