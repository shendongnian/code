    public ActionResult GetImage(int id)
    {
        var image = db.Images.Find(id);
        if (image == null)
        {
            return new HttpNotFoundResult();
        }
        return File(image.FileData, image.FileType);
    }
