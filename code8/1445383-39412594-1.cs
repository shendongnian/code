    public async Task<string> TestUpload()
    {
        var s = await UploadUtil.UploadBase64Async("kmsfan", @"D:\\b.jpg");
        return s;
    }
