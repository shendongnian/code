    // scopes define the API resources in your system
    public static IEnumerable<ApiResource> GetApiResources()
    {
        return new List<ApiResource>
        {
            new ApiResource("api1", "My API", new[] { JwtClaimTypes.Subject, JwtClaimTypes.Email, JwtClaimTypes.Phone, etc... })
        };
    }
