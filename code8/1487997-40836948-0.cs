        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            // Force to ignore Request Content Type Header and reply only JSON
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttr);
        }
