    protected void InitFields()
    {
        if (this.fields == null)
        {
            FieldDefinitionCollection definitions = new FieldDefinitionCollection(this.Store, false);
            List<FieldDefinition> list = new List<FieldDefinition>(definitions.Count);
            Dictionary<string, FieldDefinition> dictionary = new Dictionary<string, FieldDefinition>(definitions.Count, this.Store.ServerStringComparer);
            for (int i = 0; i < definitions.Count; i++)
            {
                FieldDefinition item = definitions[i];
                if (!item.IsInternal)
                {
                    list.Add(item);
                    dictionary[item.ReferenceName] = item;
                    dictionary[item.Name] = item;
                }
            }
            list.Sort(new FieldComparer(this.Store.ServerStringComparer));
            this.fields = list;
            this.fieldsMap = dictionary;
        }
    }
