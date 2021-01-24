    public object GetShapedObject<TParameter>(TParameter entity, string fields)
    {
        if (string.IsNullOrEmpty(fields))
            return entity;
        Regex regex = new Regex(@"[^,()]+(\([^()]*\))?");
        var requestedFields = regex.Matches(fields).Cast<Match>().Select(m => m.Value).Distinct();
        ExpandoObject expando = new ExpandoObject();
 
        foreach (var field in requestedFields)
        {
            if (field.Contains("("))
            {
                var navField = field.Substring(0, field.IndexOf('('));
 
                IList navFieldValue = entity.GetType()
                                        ?.GetProperty(navField, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public)
                                        ?.GetValue(entity, null) as IList;
                var regexMatch = Regex.Matches(field, @"\((.+?)\)");
                if (regexMatch?.Count > 0)
                {
                    var propertiesString = regexMatch[0].Value?.Replace("(", string.Empty).Replace(")", string.Empty);
                    if (!string.IsNullOrEmpty(propertiesString))
                    {
                        string[] navigationObjectProperties = propertiesString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
 
                        List<object> list = new List<object>();
                        foreach (var item in navFieldValue)
                        {
                            list.Add(GetShapedObject(item, navigationObjectProperties));
                        }
 
                        ((IDictionary<string, object>)expando).Add(navField, list);
                    }
                }
            }
            else
            {
                var value = entity.GetType()
                              ?.GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public)
                              ?.GetValue(entity, null);
                ((IDictionary<string, object>)expando).Add(field, value);
            }
        }
 
        return expando;
    }
