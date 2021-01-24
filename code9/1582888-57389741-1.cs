    [Fact]
    public async void TestUploadFile_byFile()
    {
    var amountOfPosts = _dbContext.Posts.Count();
    var amountOfPics = _dbContext.SmallImages.Count();
    
    sut.ControllerContext = RequestWithFile();
    var ret = await sut.UploadNewDogePOST(new Doge.Areas.User.Models.UploadDoge());
    
    var amountOfPosts2 = _dbContext.Posts.Count();
    var amountOfPics2 = _dbContext.SmallImages.Count();
    
    Assert.True(amountOfPosts < amountOfPosts2);
    Assert.True(amountOfPics < amountOfPics2);
    
    var lastImage = _dbContext.SmallImages.Include(im => im.DogeBigImage).Last();
    var sampleImagePath = host.WebRootPath + SampleImagePath;
    var b1 = new Bitmap(sampleImagePath).ToByteArray(ImageFormat.Jpeg);
    
    Assert.True(b1.Length == lastImage.DogeBigImage.Image.Length);
    
    Assert.IsType<RedirectToActionResult>(ret);
    Assert.Equal("Index", ((RedirectToActionResult)ret).ActionName);
    
    }
