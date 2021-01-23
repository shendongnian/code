    public static class ExtensionClass
    {
        // we inform compiler that this method extends any type that is derived from base type
        public static T ChangeName<T>(this T client, string newName)
           where T : BaseClient            
        {
            client.FirstName = newName;
            return client;
        }
    }
