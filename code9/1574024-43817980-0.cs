    Dictionary<string, Dictionary<string, AttributeCollection>> testingSectionFields =
                    TypeDescriptor.GetProperties(new PP_MainDataEntity())
                    .OfType<PropertyDescriptor>().ToList()
                    .GroupBy(cat => cat.Category)
                    .ToDictionary(c => c.Key, c1 => c1.ToDictionary(fld => fld.Name, fld1 => fld1.Attributes));
