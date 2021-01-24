        [HttpGet]
        public string Get()
        {
            return AboutController_Strings.AboutTitle;
        }
    This will work with `using static` trick as well:
        using static Localization.StarterWeb.AboutController_Strings;
        
        //(...)
        [HttpGet]
        public string Get()
        {
            return AboutTitle;
        }
    Alternatively you can use it with ASP's localizers. This adds no value at in that particular case but can be useful with the `IHtmlLocalizer` as it'll html-escape the values for you.
        [HttpGet]
        public string Get()
        {
            return _localizer[nameof(AboutTitle)];
        }
