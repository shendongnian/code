    public static class UtilSvc
    {
         static UtilSvc()
         {
             CreatorFunc = () => new ConfigHelper();
         }
         public static Func<IConfigHelper> CreatorFunc { get; set; }
         public static string GetConfigurationValue()
         {
             var configUtil = CreatorFunc();
             return configUtil.GetConfiguration("sectionName/sectionElement", 
                                                "ClinicalSystem");
         }
    }
