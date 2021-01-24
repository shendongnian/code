     [HttpPost("{organization}")]
        public IActionResult Post([FromForm] string asset, string organization, IFormFile fileToPost)
        {
           //Api body
           Asset asset = JsonConvert.DeserializeObject<Asset>(asset);
           //Get files from request
           Task uploadBlob = BlobFunctions.UploadBlobAsync(_blobContainer, fileToPost);
        }
