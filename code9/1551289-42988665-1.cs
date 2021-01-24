    [HttpPost]
    public ActionResult Add(Song song)
    {
        using (SongDatabase db = new SongDatabase())
        {
            db.Songs.Add(song);
            db.SaveChanges();
        }
        return RedirectToAction("Music");
    }
