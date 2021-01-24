        private static int CountElements(AutomationElement container)
        {
            var patterns = container.GetSupportedPatterns();
            var itemContainer = container.GetCurrentPattern(ItemContainerPattern.Pattern) as ItemContainerPattern;
            List<object> elements = new List<object>();
            var element = itemContainer.FindItemByProperty(null, null, null);
            while (element != null)
            {
                elements.Add(element);
                element = itemContainer.FindItemByProperty(element, null, null);
            }
            return elements.Count;
        }
