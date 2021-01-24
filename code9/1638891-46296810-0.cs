    foreach (PropertyInfo propertyInfo in dataInit.GetType().GetProperties())
            {
                if (mappingContact.ContainsKey(propertyInfo.Name) && (alreadyIn.Where(code => code == propertyInfo.Name).ToList().Count == 0))
                {
                    if (mappingContact[propertyInfo.Name].FirstOrDefault() != null)
                    {
                        if (mappingContact[propertyInfo.Name].First().GetType() == typeof(Contact))
                        {
                            Contact test = (Contact)mappingContact[propertyInfo.Name].First();
                            propertyInfo.SetValue(dataInit, mappingContact[propertyInfo.Name].Count == 1 ? test.CodeContact : null, null);
                        }
                        else
                        {
                            Adresse test = (Adresse)mappingContact[propertyInfo.Name].FirstOrDefault();
                            propertyInfo.SetValue(dataInit, mappingContact[propertyInfo.Name].Count == 1 ? test.CodeAdresse : null, null);
                        }
                    }
                }
            }
