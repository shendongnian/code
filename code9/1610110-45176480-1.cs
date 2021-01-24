    public class CustomPluralizer : IPluralizer
    {
        public string Pluralize(string identifier)
        {
            return Inflector.Pluralize(identifier) ?? identifier;
        }
        public string Singularize(string identifier)
        {
            return Inflector.Singularize(identifier) ?? identifier;
        }
    }
