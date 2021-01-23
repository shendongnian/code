      [HttpGet]
      [Route("api/mediahandler/download/{id}")]
      public async Task<HttpResponseMessage> DownloadAsset(long id)
      {
           return DownloadAsset(id, false);
      }
      [HttpGet]
      [Route("api/mediahandler/download/{id}/preview")]
      public async Task<HttpResponseMessage> DownloadAssetPreview(long id)
      {
          return DownloadAsset(id, true);
      }
      private async Task<HttpResponseMessage> DownloadAsset(long id, bool isPreview)
      {
           // action
      }
