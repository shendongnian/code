    [HttpPost]
    public ActionResult AddItems(FormCollection form)
    {
        StoreItems i = new StoreItems();
        //i.ID = int.Parse(form["AlbumID"]);
        i.AlbumName = form["AlbumName"];
        i.Artist = form["AlbumArtist"];
        i.Genre = form["AlbumGenre"];
        i.DateReleased = DateTime.Parse(form["AlbumDateReleased"]);
        i.Price = int.Parse(form["AlbumPrice"]);
        i.Downloads = int.Parse(form["AlbumDownloads"]);
        i.Listens = int.Parse(form["AlbumListens"]);
        i.RecordLabel = form["RecordLabel"];
        var files = Request.Files;
        if(files.Count > 0) {
            var file = files[0];
            i.PicturePath = file.FileName.ToString();
        } else {
            //...return some error code or validation message.
        }
        DAL.AddItems(i);
        return RedirectToAction("ItemLists");
    }
