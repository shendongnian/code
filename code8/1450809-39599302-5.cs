    public static class ExtensionClass
    {
        // we inform compiler that this method extends any type that is derived from base type
        public static T ToModel<T>(this T client)
           where T : BaseClient            
        {
            client.FirstName = "First Name Changed";
            return c;
        }
    }
