        Dictionary<string, string> mappings = new Dictionary<string, string>(){
           {"Id",    "aliasB.Id"},
           {"AName", "aliasA.Name"},
           {"BName", "aliasB.Name"}
        };
        List<FilterProperty> filters = new List<FilterProperty>();
        Junction filterCreteria = Restrictions.Conjunction();
        foreach (var filter in filters)
        {
            var mappedPropertyName = mappings[filter.Name];
            filterCreteria.Add(Restrictions.Eq(mappedPropertyName, filter.Value));
        }
