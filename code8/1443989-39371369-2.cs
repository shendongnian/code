    public IHttpActionResult UploadImage(ImageModel model)
    {
        var imgUrl = WriteImage(model.Bytes.ToArray());
    	
    	// Some code
    }
