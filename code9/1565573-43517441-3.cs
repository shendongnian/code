    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            //...DI configuration
            var formatter = (PdfMediaTypeFormatter)config.DependencyResolver.GetService(typeof(PdfMediaTypeFormatter));
            config.Formatters.Add(formatter);
        }
    }
