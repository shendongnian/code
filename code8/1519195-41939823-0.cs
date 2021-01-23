    public override void RegisterArea(AreaRegistrationContext context)
    {
      string websiteType = WebConfigurationManager.AppSettings["WebsiteType"];
      if (websiteType.Contains("spanishtutor"))
      {
        context.MapRoute(
            "SpanishTutor_Root", // Route name
            "", // override the homepage
            new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
            new[] { "Tutors.Areas.SpanishTutor.Controllers" } // namespace so there is no conflict with the namespace of the original homeapge
        );
      }
    }
