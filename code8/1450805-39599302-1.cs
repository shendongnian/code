    public static class ExtensionClass
    {
        public static T ToModel<T>(this T client)
           where T : BaseClient
        {
            client.FirstName = "First Name Changed";
            return c;
        }
    }
