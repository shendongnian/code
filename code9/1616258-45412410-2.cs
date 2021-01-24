    public class CultureResources
        {
            private static bool isAvailableCulture;
            private static readonly List<CultureInfo> SupportedCultures = new List<CultureInfo>();
            private static ObjectDataProvider provider;
            
    
            public CultureResources()
            {
                GetAvailableCultures();
            }
    
              
        
                /// <summary>
                /// Gets automatically all supported cultures resource files.
                /// </summary>
                public void GetAvailableCultures()
                {
                   
                    if (!isAvailableCulture)
                    {
                        var appStartupPath = AppDomain.CurrentDomain.BaseDirectory;
        
                        foreach (string dir in Directory.GetDirectories(appStartupPath))
                        {
                            try
                            {
                                DirectoryInfo dirinfo = new DirectoryInfo(dir);
                                var culture = CultureInfo.GetCultureInfo(dirinfo.Name);
                                SupportedCultures.Add(culture);
                            }
                            catch (ArgumentException)
                            {
                            }
                        }
                        isAvailableCulture = true;
                    }
                }
        
                /// <summary>
                /// Retrieves the current resources based on the current culture info
                /// </summary>
                /// <returns></returns>
                public Resources GetResourceInstance()
                {
                    return new Resources();
                }
        
                /// <summary>
                /// Gets the ObjectDataProvider wrapped with the current culture resource, to update all localized UIElements by calling ObjectDataProvider.Refresh()
                /// </summary>
                public static ObjectDataProvider ResourceProvider
                {
                    get {
                        return provider ??
                               (provider = (ObjectDataProvider)System.Windows.Application.Current.FindResource("Resources"));
                    }
                }
        
        
                /// <summary>
                /// Changes the culture
                /// </summary>
                /// <param name="culture"></param>
                public  void ChangeCulture(CultureInfo culture)
                {
                    if (SupportedCultures.Contains(culture))
                    {
                        Resources.Culture = culture;
                        ResourceProvider.Refresh();
                    }
                    else
                    {
                        var ci = new CultureInfo("en");
        
                        Resources.Culture = ci;
                        ResourceProvider.Refresh();
                    }
                }
        
                /// <summary>
                /// Sets english as default language
                /// </summary>
                public void SetDefaultCulture()
                {
                    CultureInfo ci = new CultureInfo("en");
        
                    Resources.Culture = ci;
                    ResourceProvider.Refresh();
                }
        
                /// <summary>
                /// Returns localized resource specified by the key
                /// </summary>
                /// <param name="key">The key in the resources</param>
                /// <returns></returns>
                public static string GetValue(string key)
                {
                    if (key == null) throw new ArgumentNullException();
                    return Resources.ResourceManager.GetString(key, Resources.Culture);
                }
        
                /// <summary>
                /// Sets the new culture
                /// </summary>
                /// <param name="cultureInfo">  new CultureInfo("de-DE");  new CultureInfo("en-gb");</param>
                public void SetCulture(CultureInfo cultureInfo)
                {
        
                    //get language short format - {de} {en} 
                    var ci = new CultureInfo(cultureInfo.Name.Substring(0,2));
                    ChangeCulture(ci);
                    Thread.CurrentThread.CurrentCulture = cultureInfo;
                    Thread.CurrentThread.CurrentUICulture = cultureInfo;
                   // CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-GB");
        
                }
            }
