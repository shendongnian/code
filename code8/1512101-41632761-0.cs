            [HttpPost]
            [Route("Upload/Image")]
            public async Task<IHttpActionResult> UploadImg()
            {
                try
                {
                    #region VAR
    
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(string.Concat("~", Constant.Application.User_Cropped_Image_Directory)))) ;
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(string.Concat("~", Constant.Application.User_Cropped_Image_Directory)));
    
                    string mapPath = HttpContext.Current.Server.MapPath(string.Concat("~", Constant.Application.User_Cropped_Image_Directory));
    
                    HttpRequestMessage request = this.Request;
                    String fileName = "";
    
                    #endregion VAR
    
                    #region SPLIT
    
                    // Get base64 string from POST
                    var base64String = request.Content.ReadAsStringAsync().Result;
                    // SPLIT Content from unecessary data
                    var split = base64String.Split(',');
                    var strings = split[1].Split('-');
    
                    #endregion SPLIT
    
                    // Convert Base64 String to byte[]
                    byte[] imageBytes = Convert.FromBase64String(strings[0]);
                    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
    
                    // Convert byte[] to Image
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    Image image = Image.FromStream(ms, true);
                    if (!Directory.Exists(String.Concat(mapPath, fileName).ToLowerInvariant()))
                        Directory.CreateDirectory(String.Concat(mapPath, fileName).ToLowerInvariant());
    
                    fileName = GenericUtils.GetFileNameWithExt(image).ToLowerInvariant();
    
                    //name = String.Concat("croppedImage_", fileName);
                    image.Save(String.Concat(mapPath, fileName).ToLowerInvariant());
    
                  
    
                    return Ok(new { data = String.Concat(Constant.Application.User_Cropped_Image_Directory, fileName).ToLowerInvariant() } );
                }
                catch (Exception ex)
                {
                    _logger.LogException(ex);
                    return null;
                }
            }
