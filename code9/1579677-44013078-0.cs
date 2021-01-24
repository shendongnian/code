    public static bool IsElementVisibleInView([NotNull] this View view, [NotNull] Element el)
        {
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }
            if (el == null)
            {
                throw new ArgumentNullException(nameof(el));
            }
            // Obtain the element's document
            Document doc = el.Document;
            ElementId elId = el.Id;
            // Create a FilterRule that searches for an element matching the given Id
            FilterRule idRule = ParameterFilterRuleFactory.CreateEqualsRule(new ElementId(BuiltInParameter.ID_PARAM), elId);
            var idFilter = new ElementParameterFilter(idRule);
            // Use an ElementCategoryFilter to speed up the search, as ElementParameterFilter is a slow filter
            Category cat = el.Category;
            var catFilter = new ElementCategoryFilter(cat.Id);
            // Use the constructor of FilteredElementCollector that accepts a view id as a parameter to only search that view
            // Also use the WhereElementIsNotElementType filter to eliminate element types
            FilteredElementCollector collector =
                new FilteredElementCollector(doc, view.Id).WhereElementIsNotElementType().WherePasses(catFilter).WherePasses(idFilter);
            // If the collector contains any items, then we know that the element is visible in the given view
            return collector.Any();
        }
