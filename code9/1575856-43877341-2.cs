    public ActionResult RetrievePageText(int ContentID) {
        PageContent PC = New PageContent(ContentID);
        string[] PageLines = PC.PageText.split('.');
        return View(PageLines);
    }
