    public ActionResult Portrait(int id)
    {
        vPhotos p = sdb.vPhotos.Where(e => e.ID == id).SingleOrDefault();
        byte[] photoArray = new byte[] { };
        return File(smallPhotoArray, "image/png");
    }
