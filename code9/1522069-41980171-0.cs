    public class MvcApplication : System.Web.HttpApplication
    {
        private const string LanguageCode = "nl-NL";
        private const DayTime CurrentDayTime = DayTime.Night;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SetCurrentUserLanguage();
            ReplaceResourceFile(typeof(DayTimeResources), CurrentDayTime == DayTime.Day ? typeof(DayResources) : typeof(NightResources));
        }
        private void SetCurrentUserLanguage()
        {
            CultureInfo cultureInfo = new CultureInfo(LanguageCode);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }
        private void ReplaceResourceFile(Type originalType, Type replaceType)
        {
            FieldInfo fieldInfo = originalType.GetField("resourceMan", BindingFlags.NonPublic | BindingFlags.Static);
            ResourceManager resourceManager = new ResourceManager(replaceType.FullName, replaceType.Assembly);
            fieldInfo.SetValue(null, resourceManager);
            fieldInfo = originalType.GetField("resourceCulture", BindingFlags.NonPublic | BindingFlags.Static);
            fieldInfo.SetValue(null, CultureInfo.CurrentUICulture);
        }
    }
