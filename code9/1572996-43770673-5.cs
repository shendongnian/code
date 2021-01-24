        public class JsonDotNetConfigProvider : TableControllerConfigProvider
        {
            public override void Configure(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
            {
                base.Configure(controllerSettings, controllerDescriptor);
                controllerSettings.Formatters.Insert(0, new JsonDotNetFormatter());
            }
        }
