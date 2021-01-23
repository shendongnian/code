    public static IEnumerable<SelectListItem> ListOfLanguages()
    {
        var langs = _languageRepository.Languages.Select( x => new SelectListItem
        {
            Value = x.Index,
            Text = x.Name
        });
        return new SelectList( langs, "Value", "Text");
    }
    public ActionResult show( Language lang = null )
    {
        lang = _languageRepository.Find(x => x.Index == label.Language.Index );        
        return View( lang );
    }
