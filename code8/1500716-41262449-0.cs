    private void BindFilter(DropDownList ddl, string field, IEnumerable<dynamic> items)
    {
        ddl.Items.Clear();
        foreach (var item in items)
        {
            var propertyInfo = item.GetType().GetProperty(field);
            var value = propertyInfo.GetValue(item, null);
            ddl.Items.Add(value.ToString());
        }
    }
