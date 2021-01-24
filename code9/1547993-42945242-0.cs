    public Task<ActionResult> GetStudentImage(string id)
    {
         var image = mongo.GetCollection<Image>("Image").AsQueryable().First(x => x.Id == id);
       return File(image.ImageBytes.ToArray(), "image/png"); // the image in bytes
    }
