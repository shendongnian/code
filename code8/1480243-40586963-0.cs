    public virtual ActionResult FileDisplay(int fileId, bool isFile)
    {
        var viewmodel = _presenter.GetDocumentDisplayViewModel(fileId, isFile);
        ViewBag.Title= viewmodel.FileName;
        return base.File(viewmodel.Data, viewmodel.MediaType);
    }
