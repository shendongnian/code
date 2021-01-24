    [Authorize]
    [RoutePrefix("api/File")]
    
     public class FileController : ApiController
        {
    		IFileService fileService = null;
            public FileController(IFileService _fileService)
            {
                fileService = _fileService;
            }
    		
    		[Route("Upload"), HttpPost]
            public async Task<IHttpActionResult> Upload()
            {
                #region Condition
    			
                if (!Request.Content.IsMimeMultipartContent())
                    return Content(HttpStatusCode.UnsupportedMediaType, Messages.FUW0001);
                #endregion
    
                /// `localPath` and `useCloud` is get from Web.Config.
                string localPath = HostingEnvironment.MapPath(ConfigurationManager.AppSettings["fileServiceLocalPath"]);
                bool useCloud = Convert.ToBoolean(ConfigurationManager.AppSettings["useCloud"]);
    
                var provider = new MultipartFormDataStreamProvider(localPath);
    
                try
                {
                    /// Loads the files into the local storage.
                    await Request.Content.ReadAsMultipartAsync(provider);
                    
                    /// Check is exist valid file.
                    if (provider.FileData.Count == 0)
                        return BadRequest(Messages.FUE0001 /*Message Type FUE001 = File Not Found */);
    
                    IList<FileDto> modelList = new List<FileDto>();
    
                    foreach (MultipartFileData file in provider.FileData)
                    {
                        string originalName = file.Headers.ContentDisposition.FileName;
                        if (originalName.StartsWith("\"") && originalName.EndsWith("\""))
                        {
                            originalName = originalName.Trim('"');
                        }
                        if (originalName.Contains(@"/") || originalName.Contains(@"\"))
                        {
                            originalName = Path.GetFileName(originalName);
                        }
    
    					/// File information storage my database.
                        FileDto fileDto = new FileDto
                        {
                            OriginalName = Path.GetFileNameWithoutExtension(originalName),
                            StorageName = Path.GetFileName(file.LocalFileName),
                            Extension = Path.GetExtension(originalName).ToLower().Replace(".", ""),
                            Size = new FileInfo(file.LocalFileName).Length
                        };
    
                        modelList.Add(fileDto);
                    }
    
                    if (useCloud)
                        await fileService.SendCloud(modelList,localPath);
    
                    await fileService.Add(modelList, IdentityClaimsValues.UserID<Guid>());
    
                    return Ok(Messages.Ok);
                }
                catch (Exception exMessage)
                {
                    return Content(HttpStatusCode.InternalServerError, exMessage);
                }
            }
    	
    	[	Route("Download"), HttpGet]
            public async Task<IHttpActionResult> Download(Guid id)
            {
    			/// Get file information my database
                var model = await fileService.GetByID(id);
    
                if (model == null)
                    return BadRequest();
    
                /// `localPath` is get from Web.Config.
                string localPath = HostingEnvironment.MapPath(ConfigurationManager.AppSettings["fileServiceLocalPath"]);
    
                string root = localPath + "\\" + model.StorageName;
    
                byte[] fileData = File.ReadAllBytes(root);
                var stream = new MemoryStream(fileData, 0, fileData.Length);
    
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(stream.ToArray())
                };
    
                response.Content.Headers.ContentDisposition =
                    new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = model.OriginalName + "." + model.Extension,
                        Size=model.Size
                    };
    
                response.Content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/octet-stream");
    
                IHttpActionResult result = ResponseMessage(response);
                return result;
            }
    	
    		[Route("ImageReview"), HttpGet]
            public async Task<IHttpActionResult> ImageReview(Guid id)
            {
    			/// Get file information my database
                var model = await fileService.GetByID(id);
    
                if (model == null)
                    return BadRequest();
    
                /// `localPath` is get from Web.Config.
                string localPath = HostingEnvironment.MapPath(ConfigurationManager.AppSettings["fileServiceLocalPath"]);
    
                string root = localPath + "\\" + model.StorageName;
    
                byte[] fileData = File.ReadAllBytes(root);
                var stream = new MemoryStream(fileData, 0, fileData.Length);
    
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StreamContent(stream)
                };
    
                response.Content.Headers.ContentType =
                    new MediaTypeHeaderValue("image/"+ model.Extension);
    
                IHttpActionResult result = ResponseMessage(response);
    
                return result;
            }
    	}
