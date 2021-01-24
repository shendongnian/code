    private ControllerContext RequestWithFile()
    {
    var httpContext = new DefaultHttpContext();
    httpContext.Request.Headers.Add("Content-Type", "multipart/form-data");
                
    var sampleImagePath = host.WebRootPath + SampleImagePath; //path to correct image    
    var b1 = new Bitmap(sampleImagePath).ToByteArray(ImageFormat.Jpeg);
    
    MemoryStream ms = new MemoryStream(b1);    
    var fileMock = new Mock<IFormFile>();
                
    fileMock.Setup(f => f.Name).Returns("files");
    fileMock.Setup(f => f.FileName).Returns("sampleImage.jpg");
    fileMock.Setup(f => f.Length).Returns(b1.Length);
    fileMock.Setup(_ => _.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
    .Returns((Stream stream, CancellationToken token) => ms.CopyToAsync(stream))
    .Verifiable();              
    
    string val = "form-data; name=";      
    val += "\\";
    val += "\"";
    val += "files";
    val += "\\";
    val += "\"";
    val += "; filename=";
    val += "\\";
    val += "\"";
    val += "sampleImage.jpg";
    val += "\\";
    val += "\"";
                  
                  
    fileMock.Setup(f => f.ContentType).Returns(val);
    fileMock.Setup(f => f.ContentDisposition).Returns("image/jpeg");      
    
       
    httpContext.User = ClaimsPrincipal; //user part, you might not need it
    httpContext.Request.Form = 
    new FormCollection(new Dictionary<string, StringValues>(), new FormFileCollection { fileMock.Object });
    var actx = new ActionContext(httpContext, new RouteData(), new ControllerActionDescriptor());
                   
    return new ControllerContext(actx);
    }
