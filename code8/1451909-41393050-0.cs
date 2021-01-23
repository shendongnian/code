    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    namespace TestApp.WebUi
    {
        public static class PreApplicationStart
        {
            private static bool _isStarting;
            public static void PreStart()
            {
                if (!_isStarting)
                {
                    _isStarting = true;
                    DynamicModuleUtility.RegisterModule(typeof(UnityHttpModule));
                }
            }
        }
    }
 
