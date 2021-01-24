    private class CombinedPageRouteModelConvention : IPageRouteModelConvention
        {
            private const string BaseUrlTemplateWithoutSegment = "{language}/shop";
            private const string BaseUrlTemplateWithSegment = "{language}/{segment}/shop";
            public void Apply(PageRouteModel model)
            {
                var allSelectors = new List<SelectorModel>();
                foreach (var selector in model.Selectors)
                {
                    //setup the route with segment
                    allSelectors.Add(CreateSelector(selector, BaseUrlTemplateWithSegment));
                    //setup the route without segment
                    allSelectors.Add(CreateSelector(selector, BaseUrlTemplateWithoutSegment));
                }
                //replace the default selectors with new selectors
                model.Selectors.Clear();
                foreach (var selector in allSelectors)
                {
                    model.Selectors.Add(selector);
                }
            }
            private static SelectorModel CreateSelector(SelectorModel defaultSelector, string template)
            {
                var fullTemplate = AttributeRouteModel.CombineTemplates(template, defaultSelector.AttributeRouteModel.Template);
                var newSelector = new SelectorModel(defaultSelector)
                {
                    AttributeRouteModel =
                    {
                        Template = fullTemplate
                    }
                };
                return newSelector;
            }
        }
