    > NOTE: because the generated statements are using parameters, and we are not yet reading the parameter values, we will not need to regenerate the saved SQL statements later after we have found an Id value to insert to other objects... phew... 
        public void Add(object item)
        {
            List<string> propertyNames = new List<string>();
            Type itemType = item.GetType();
            System.Reflection.PropertyInfo[] properties = itemType.GetProperties();
            for (int I = 0; I < properties.Count(); I++)
            {
                if (properties[I].Name.Equals("Id", StringComparison.CurrentCultureIgnoreCase) || properties[I].Name.Equals("AutoId", StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }
                propertyNames.Add(properties[I].Name);
            }
            string itemName = itemType.Name;
            KeyValuePair<string, object> command = new KeyValuePair<string, object>
                ($"Insert Into[{itemName}] ({String.Join(",", propertyNames.Select(p => $"[{p}]"))}) Values({String.Join(",", propertyNames.Select(p => $"@{p}"))}); SET @OutId = SCOPE_IDENTITY();", item);
            transactions.Add(command);
            // Simply append your statement with a set command on an @id parameter we will add in SaveChanges()
        }
