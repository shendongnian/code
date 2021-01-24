    public ActionResult Settings()
    {
       List<Language> activeL = LanguageController.GetAll();
       ViewBag.Languagess = activeL;
       return View();
}
