     public class MvcApplication : HttpApplication
        {
            protected void Application_Start()
            {
                AreaRegistration.RegisterAllAreas();
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
                log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));
                ModelBinders.Binders.Add(typeof(BaseRequestData), new BaseRequestDataModelBinder());
            }
        }
    
        public class BaseRequestDataModelBinder : DefaultModelBinder
        {
            protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
            {
                ValueProviderResult typeValue = bindingContext.ValueProvider.GetValue(bindingContext.ModelName + ".ModelType");
                Type type = Type.GetType(
                    (string)typeValue.ConvertTo(typeof(string)),
                    true
                );
                object model = Activator.CreateInstance(type);
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, type);
                return model;
            }
        }
