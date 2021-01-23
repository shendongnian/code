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
                var expandoCase = extensionHolder as IDictionary<string, object>;
                if (expandoCase == null)
                {
                    // Pour chaque propriété
                    foreach (var property in ((object)extensionHolder).GetType().GetProperties())
                    {
                        // Faire la copie sur l'ExpandoObject (qui gère nativement le rajout de propriété) en utilisant les données extraites de l'objet dynamique
                        dynamicReturnedEditable[property.Name] = property.GetValue(extensionHolder, null);
                    }
                }
                else
                {
                    foreach (var propertyName in expandoCase.Keys)
                    {
                        // Faire la copie sur l'ExpandoObject (qui gère nativement le rajout de propriété) en utilisant les données extraites de l'objet dynamique
                        dynamicReturnedEditable[propertyName] = expandoCase[propertyName];
                    }
                }
            }
            return r;
    }
