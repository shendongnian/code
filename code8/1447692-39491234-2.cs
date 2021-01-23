    [RoutePrefix("api/mediahandler/download")]
    public class MediaHandlerController : ApiControllerBase
    {
          [HttpGet]
          [Route("{id}")]
          public async Task<HttpResponseMessage> DownloadAsset(long id)
          {
               return DownloadAsset(id, false);
          }
          [HttpGet]
          [Route("{id}/preview")]
          public async Task<HttpResponseMessage> DownloadAssetPreview(long id)
          {
              return DownloadAsset(id, true);
          }
          private async Task<HttpResponseMessage> DownloadAsset(long id, bool isPreview)
          {
               // action
          }
    }
