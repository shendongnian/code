        public HtmlDiv GetPaneID(UITestControl parent, string id)
        {
            var gpane = new HtmlDiv(parent);
            gpane.SearchProperties.Add(HtmlDiv.PropertyNames.Id, id);
            return gpane;
        }
