    var parent = ContentReference.RootPage;
    
    IContentRepository contentRepository = 
        EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<IContentRepository>();
    StartpagePage startpage = contentRepository.GetDefault<StartpagePage>(parent);
    
    startpage.PageName = "Teststartsida";
    startpage.Title = "Teststartsida";
    
    // this will create a startpage in Swedish, use SaveAction.Publish
    // save the page into a new variable
    var createdPage = contentRepository.Save(startpage,
        EPiServer.DataAccess.SaveAction.Publish, 
        AccessLevel.NoAccess);
    
    // invoke CreateLanguageBranch with LanguageSelector
    var startpageLanguageBranch = 
        contentRepository.CreateLanguageBranch<StartpagePage>(createdPage, 
            new LanguageSelector("en"));
    
    startpageLanguageBranch.PageName = "Start page test";
    startpageLanguageBranch.Title = "Start page test";
    
    // this will create a languagebranch in the language stated with the LanguageSelector. 
    // Use SaveAction.Save
    contentRepository.Save(startpageLanguageBranch, 
        EPiServer.DataAccess.SaveAction.Save, 
        AccessLevel.NoAccess);
