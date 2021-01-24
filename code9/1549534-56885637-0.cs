    public class CustomFromQueryAttribute : FromQueryAttribute
    {
        public CustomFromQuery(string name)
        {
            Name = name.ToSnakeCase();
        }
    }
