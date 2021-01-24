    ApplicationContext applicationContext = ApplicationContext.Current;
    // Obtain the Umbraco Content Service
    var contentService = applicationContext.Services.ContentService;
    // Obtain content template
    var contentTemplate = contentService.GetBlueprintById(contentTemplateId);
