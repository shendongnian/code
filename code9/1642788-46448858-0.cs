    public ActionResult Note(RaporModel Filter, int? ID)
    {
        var prjnote = db.tbl_ProjectNot.FirstOrDefault(d => d.ID == ID);
        if (prjnote == null)
            prjnote = new tbl_ProjectNot();
        return PartialView(prjnote);
    }
