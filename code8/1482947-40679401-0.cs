	/// <summary>
	/// Constructor for populating via LINQ queries given a LINQ anonymous type
	/// <param name="anonymousType">LINQ anonymous type.</param>
	/// </summary>
	[System.Diagnostics.DebuggerNonUserCode()]
	public Project(object anonymousType) : 
			this()
	{
        foreach (var p in anonymousType.GetType().GetProperties())
        {
            var value = p.GetValue(anonymousType, null);
            var name = p.Name.ToLower();
        
            if (name.EndsWith("enum") && value.GetType().BaseType == typeof(System.Enum))
            {
                value = new Microsoft.Xrm.Sdk.OptionSetValue((int) value);
                name = name.Remove(name.Length - "enum".Length);
            }
        
            switch (name)
            {
                case "id":
                    base.Id = (System.Guid)value;
                    Attributes["projectid"] = base.Id;
                    break;
                case "productid":
                    var id = (System.Nullable<System.Guid>) value;
                    if(id == null){ continue; }
                    base.Id = id.Value;
                    Attributes[name] = base.Id;
                    break;
                case "formattedvalues":
                    // Add Support for FormattedValues
                    FormattedValues.AddRange((Microsoft.Xrm.Sdk.FormattedValueCollection)value);
                    break;
                default:
                    Attributes[name] = value;
                    break;
            }
        }
	}
