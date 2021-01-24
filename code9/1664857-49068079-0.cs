        /// <summary>
        /// Upload a .pdf file for a particular [User] record
        /// </summary>
        [AllowAnonymous]
        [HttpPost("uploadPDF/{UserId}")]
        public async Task<IActionResult> uploadPDF(string UserId, IFormFile inputFile)
        {
            try
            {
                if (string.IsNullOrEmpty(UserId))
                    throw new Exception("uploadPDF service was called with a blank ID.");
                Guid id;
                if (!Guid.TryParse(RequestId, out id))
                    throw new Exception("uploadPDF service was called with a non-GUID ID.");
                var UserRecord = dbContext.Users.FirstOrDefault(s => s.UserID == id);
                if (UserRecord == null)
                    throw new Exception("User record not found.");
                var UploadedFileSize = Request.ContentLength;
                if (UploadedFileSize == 0)
                    throw new Exception("No binary data received.");
                var values = Request.ReadFormAsync();
                IFormFileCollection files = values.Result.Files;
                if (files.Count == 0)
                    throw new Exception("No files were read in.");
                IFormFile file = files.First();
                using (Stream stream = file.OpenReadStream())
                {
                    BinaryReader reader = new BinaryReader(stream);
                    byte[] bytes = reader.ReadBytes((int)UploadedFileSize);
                    Trace.WriteLine("Saving PDF file data to database..");
                    UserRecord.RawData = bytes;
                    UserRecord.UpdatedOn = DateTime.UtcNow;
                    dbContextWebMgt.SaveChanges();
                }
                return new OkResult();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "uploadPDF failed");
                return new BadRequestResult();
            }
        }
