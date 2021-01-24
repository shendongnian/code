    [HttpPost]
    public ActionResult Add(Song song)
    {
        using (SongDatabase db = new SongDatabase())
        {
            SongDatabase.Songs.Add(song);
            SongDatabase.SaveChanges();
        }
        return RedirectToAction("Music");
    }
