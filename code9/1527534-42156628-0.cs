    public class LocalizedControllerActivator : IControllerActivator
    {
        private string _DefaultLanguage = "it";
        public IController Create(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            //Get the {language} parameter in the RouteData
            string lang = (string)requestContext.RouteData.Values["lang"] ?? _DefaultLanguage;
            try
            {
                System.Threading.Thread.CurrentThread.CurrentCulture =
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            }
            catch (Exception e)
            {
                throw new NotSupportedException(String.Format("ERROR: Invalid language code '{0}'.", lang));
            }
            return DependencyResolver.Current.GetService(controllerType) as IController;
        }
    }
