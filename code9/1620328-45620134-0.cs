    class MultiLanguageStringNamingConvention : IStoreModelConvention<EdmProperty>
        {
            public void Apply(EdmProperty property, DbModel model)
            {
                string propertyName = string.Format("_{0}", nameof(MultiLanguageString.MultiLanguageString_Serialized));
                if (property.TypeName.ToLower() == "nvarchar(max)" && property.Name.EndsWith(propertyName))
                {
                    property.Name = property.Name.Replace(propertyName, "");
                }
            }
        }
