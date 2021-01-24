    [ChildActionOnly]
    public PartialViewResult Contact
    {
        return PartialView("_QuickContact"); // or return PartialView("_QuickContact", new ContactForm());
    }
