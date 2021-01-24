    public static class UtilSvc
    {
         static UtilSvc()
         {
             CreatorFunc = () => new ConfigHelper();
         }
         public static Func<ConfigHelper> CreatorFunc { get; set; }
         public static string GetConfigurationValue()
         {
             var configUtil = CreatorFunc();
             return configUtil.GetConfiguration("sectionName/sectionElement", 
                                                "ClinicalSystem");
         }
    }
