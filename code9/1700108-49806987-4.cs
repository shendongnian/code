        public ViewLocationCacheKey(
            string viewName,
            bool isMainPage)
        public ViewLocationCacheKey(
            string viewName,
            string controllerName,
            string areaName,
            string pageName,
            bool isMainPage,
            IReadOnlyDictionary<string, string> values)
