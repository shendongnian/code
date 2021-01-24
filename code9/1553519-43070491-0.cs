        public static void RegisterFormatters(MediaTypeFormatterCollection formatters)
        {
            var jsonp = new JsonpMediaTypeFormatter(formatters.JsonFormatter);
            jsonp.MediaTypeMappings.Add(new QueryStringMapping("type", "jsonp", "application/json"));
            GlobalConfiguration.Configuration.Formatters.Add(jsonp);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("type", "json", "application/json"));
        }
