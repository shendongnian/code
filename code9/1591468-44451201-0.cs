    public class CustomMsSql2012Dialect : MsSql2012Dialect
    {
        public CustomMsSql2012Dialect()
        {
            RegisterKeyword("my_table_alias");
            ...
