        public static PropertyValue GetPropertyValue(int propertyDefId, object value)
        {
            //resolve property def by ID
            PropertyDef propertyDef = Vault.PropertyDefOperations.GetPropertyDef(propertyDefId);
            //create the property value with prop def ID and value
            return GetPropertyValue(propertyDefId, propertyDef.DataType, value);
        }
        public static PropertyValue GetPropertyValue(int propertyDefId, MFDataType dataType, object value)
        {
            PropertyValue propertyValue = new PropertyValue();
            propertyValue.PropertyDef = propertyDefId;
            propertyValue.TypedValue.SetValue(dataType, value);
            return propertyValue;
        }
        public static ObjectVersionAndProperties CreateDocument(PropertyValues propertyValues, string filepath, Vault vault)
        {
            // Create the Source File object from the filepath.
            SourceObjectFile sourceFile = new SourceObjectFile();
            sourceFile.SourceFilePath = filepath;
            sourceFile.Extension = Path.GetExtension(filepath).TrimStart('.');
            sourceFile.Title = Path.GetFileNameWithoutExtension(filepath).TrimEnd('.');
            // Create the document object.
            return vault.ObjectOperations.CreateNewSFDObject((int)MFBuiltInObjectType.MFBuiltInObjectTypeDocument,
                propertyValues, sourceFile, true);
        }
