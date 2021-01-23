        [HttpPost]
        [Route("Profile/Image")]
        public Task<HttpResponseMessage> UploadImgProfile()
                {
                    try
                    {
                        if (!ModelState.IsValid) return null;
        
                        var currentUser = _userUtils.GetCurrentUser(User);
                        if (currentUser == null) return null;
        
                        HttpRequestMessage request = this.Request;
                        if (!request.Content.IsMimeMultipartContent())
                            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType));
        
                        string root = HttpContext.Current.Server.MapPath("~" + Constant.Application.User_Image_Directory);
        
                        bool exists = Directory.Exists(root);
                        if (!exists)
                            Directory.CreateDirectory(root);
        
                        var provider = new   MultipartFormDataStreamProvider(root);
        
                    
    
         
    
         var task = request.Content.ReadAsMultipartAsync(provider).
                        ContinueWith<HttpResponseMessage>(o =>
                        {
                            var finfo = new     FileInfo(provider.FileData.First().LocalFileName);
        
              string guid = Guid.NewGuid().ToString();
        
              var fileName = guid + "_" + currentUser.IdOwin + ".jpg"; 
    
                            File.Move(finfo.FullName, Path.Combine(root, fileName));
    
                            return new HttpResponseMessage()
                            {
                                Content = new StringContent(Path.Combine(Constant.Application.User_Image_Directory, fileName))
                            };
                            }
                            );
                        return task;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogException(ex);
                        return null;
                    }
                }
