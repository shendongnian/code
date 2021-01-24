        private void SetVisibleSearchOptions(Type searchType, bool visible)
        {
            try
            {
                TypeDescriptor.AddAttributes(searchType, new BrowsableAttribute(visible));
            }
            catch (Exception ex)
            {
            }
        }
