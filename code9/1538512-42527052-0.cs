        Object[] props = o.GetDynamicBlockProperties();
        foreach (var prop in props.OfType<AcadDynamicBlockReferenceProperty>())
        {
            if (prop.PropertyName == "My_Table")
            {
                if (prop.Value != 0)
                    prop.Value = (short)0; // <- reset to the first row
            }
        }
