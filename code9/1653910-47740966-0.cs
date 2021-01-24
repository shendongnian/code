    public class MyApplication : OpenIddictApplication<string, MyAuthorization, MyToken>
    {
        public MyApplication() => Id = Guid.NewGuid().ToString();
    }
    public class MyAuthorization : OpenIddictAuthorization<string, MyApplication, MyToken>
    {
        public MyAuthorization() => Id = Guid.NewGuid().ToString();
    }
    public class MyScope : OpenIddictScope<string>
    {
        public MyScope() => Id = Guid.NewGuid().ToString();
    }
    public class MyToken : OpenIddictToken<string, MyApplication, MyAuthorization>
    {
        public MyToken() => Id = Guid.NewGuid().ToString();
    
        public string DeviceId { get; set; }
    }
