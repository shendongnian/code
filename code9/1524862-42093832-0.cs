        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> UploadUserPicture()
        {
            // collect name image server
            var imageServer = _optionsAccessor.Value.ImageServer;
            // collect image in Request Form from Slim Image Cropper plugin
            var json = _httpContextAccessor.HttpContext.Request.Form["slim[]"];
            // Collect access token to be able to call API
            var accessToken = await HttpContext.Authentication.GetTokenAsync("access_token");
            // prepare api call to update image on imageserver and update database
            var client = _httpClientsFactory.Client("imageServer");
            client.DefaultRequestHeaders.Accept.Clear();
            client.SetBearerToken(accessToken);
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("image", json[0])
            });
            HttpResponseMessage response = await client.PostAsync("api/UserPicture/UploadUserPicture", content);
            
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            return StatusCode((int)HttpStatusCode.OK);
        }
