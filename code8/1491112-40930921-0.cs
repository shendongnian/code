    public static dynamic DynamicExtend(params dynamic[] extendedItems)
    {
            if (extendedItems == null || extendedItems.Length == 0 || extendedItems[0] == null)
                throw new Exception("Missing initial dynamic property");
            if (extendedItems.Length == 1)
                return extendedItems.First();
            dynamic r = new ExpandoObject();
            // We will need that casted value or the r[propertyName]="someValue" will fail
            var dynamicReturnedEditable = (IDictionary<string, object>)r;
            // For each dynamic object passed in
            foreach (dynamic extensionHolder in extendedItems)
            {
                // For each property of that dynamic object
                foreach (var property in ((object)extensionHolder).GetType().GetProperties())
                {
                    // Do the copy to the ExpandoObject (which natively supports adding properties when we use the dictionnary interface) from the property of the dynamic object
                    dynamicReturnedEditable[property.Name] = property.GetValue(extensionHolder);
                }
            }
            return r;
    }
