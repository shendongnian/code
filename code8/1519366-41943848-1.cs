        public void visit(IUIItem item)
        {
            if (item is CustomUIItem)
            {
                // Process custom controls
                CustomUIItem customControl = item as CustomUIItem;
                // Retrieve all the child controls
                IUIItem[] items = customControl.AsContainer().GetMultiple(SearchCriteria.All);
                
                // visit all the children
                foreach (var t in items)
                {
                    visit(t);
                }
                ...
            }
            else
            {
                // Process normal controls
                ...
            }
        }
