        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult UploadUserPicture(String image)
        {
         dynamic jsonDe = JsonConvert.DeserializeObject(image);
            if (jsonDe == null)
            {
            	return new StatusCodeResult((int)HttpStatusCode.NotModified);
            }
            // create filname for user picture
            string userId = jsonDe.meta.userid;
            string userHash = Hashing.GetHashString(userId);
            string fileName = "User" + userHash + ".jpg";
            // create a new version number
            string pictureVersion = DateTime.Now.ToString("yyyyMMddHHmmss");
            // get the image bytes and create a memory stream
            var imagebase64 = jsonDe.output.image;
            var cleanBase64 = Regex.Replace(imagebase64.ToString(), @"^data:image/\w+;base64,", "");
            var bytes = Convert.FromBase64String(cleanBase64);
            var memoryStream = new MemoryStream(bytes);
            // save the image to the folder
            var fileSavePath = Path.Combine(_env.WebRootPath + ("/imageuploads"), fileName);
            FileStream file = new FileStream(fileSavePath, FileMode.Create, FileAccess.Write);
            try
            {
                memoryStream.WriteTo(file);
            }
            catch (Exception ex)
            {
                _logger.LogDebug(LoggingEvents.UPDATE_ITEM, ex, "Could not write file >{fileSavePath}< to server", fileSavePath);
                return new StatusCodeResult((int)HttpStatusCode.NotModified);
            }
            memoryStream.Dispose();
            file.Dispose();
            memoryStream = null;
            file = null;
            // update database with latest filename and version
            bool isUpdatedInDatabase = UpdateDatabaseUserPicture(userId, fileName, pictureVersion).Result;
            if (!isUpdatedInDatabase)
            {
                return new StatusCodeResult((int)HttpStatusCode.NotModified);
            }
            return new StatusCodeResult((int)HttpStatusCode.OK);
        }
