    public static class EnumExtensions
    {
        public static BookDetails GetDescription(this Books value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attribute = fieldInfo.GetCustomAttributes(typeof(BookDetails), false).FirstOrDefault() as BookDetails;
            return attribute;
        }
    }
