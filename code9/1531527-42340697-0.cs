    var customConfig = (DataExtractorConfig)config.GetSection(sectionName);
    
    if (customConfig != null && customConfig.ElementInformation.IsPresent)
    {
       if(customConfig.ParallelProcessing.ElementInformation.IsPresent)
       {
          // TODO
       }
       else
       {
          // TODO
       }
       dynSettingClass = customConfig;
    }
