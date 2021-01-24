    public static class OrmLiteExtensions
    {
        public static string GetQuotedName<T>(string propertyName, bool appendTablePrefix = true)
        {
            var sqlFieldName = string.Empty;
            var modelDefinition = typeof(T).GetModelMetadata();
            if (appendTablePrefix)
                sqlFieldName = OrmLiteConfig.DialectProvider.GetQuotedName(modelDefinition.ModelName) + ".";
            sqlFieldName += modelDefinition.FieldDefinitions.First(p => p.Name == propertyName).GetQuotedName(OrmLiteConfig.DialectProvider);
            return sqlFieldName;
        }
    }
