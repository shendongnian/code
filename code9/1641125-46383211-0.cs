        public void ConfigureServices(IServiceCollection services)
        {                        
            
            services.AddMemoryCache();
    services.AddAuthentication(Authentication.Hmac.HmacDefaults.AuthenticationScheme).AddHmac(options =>
                    {
                        options.AuthName = "myname";
                        options.CipherStrength = HmacCipherStrength.Hmac256;
                        options.EnableNonce = true;
                        options.RequestTimeLimit = 5;
                        options.PrivateKey = "myprivatekey";
                        // do your stuff with Test class here
                    });
           
        }
    public class Test {
      private IMemoryCache _cache;
      public Test(IMemoryCache cache) {
        _cache = cache;
      }
    }
