    public ActionResult Gallery(string Album, string albumPath)
    {
        GalleryModel model = new GalleryModel();
        model.albumPath = ("~/photos/" + Album);
        return View(model);
    }
