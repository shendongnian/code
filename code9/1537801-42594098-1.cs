    public static IEnumerable<ApiResource> GetApiResources()
    {
        return new List<ApiResource>
        {
            // this will incorrectly leave out the ApiScope record in the database, but will create the ApiResoure and ApiSecret records
            new ApiResource
            {
                Name = "MyAPI",
                DisplayName = "My API",
                ApiSecrets =
                {
                    new Secret("TopSecret".Sha256()),
                }
            },
            // this will correctly create the ApiResource, ApiScope, and ApiSecret records in the database.
            new ApiResource("MyAPI2", "My API2")
            {
                ApiSecrets =
                {
                    new Secret("TopSecret2".Sha256())
                }
            }
        };
    }
