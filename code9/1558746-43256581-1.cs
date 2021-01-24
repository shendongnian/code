    public ActionResult MediaMain () {
        var model = new MediaViewModel();
        model.media = db.Medias.ToList();
        model.video = db.Videos.Tolist();
        return View(model);
    }
