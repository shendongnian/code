    public interface IDistributedCache1 : IDistributedCache
    {
    }
    
    public interface IDistributedCache2 : IDistributedCache
    {
    }
    
    public class RedisCacheOptions1 : RedisCacheOptions
    {
    }
    
    public class RedisCacheOptions2 : RedisCacheOptions
    {
    }
    
    public class RedisCache1 : RedisCache, IDistributedCache1
    {
    	public RedisCache1(IOptions<RedisCacheOptions1> optionsAccessor) : base(optionsAccessor)
    	{
    	}
    }
    
    public class RedisCache2 : RedisCache, IDistributedCache2
    {
    	public RedisCache2(IOptions<RedisCacheOptions2> optionsAccessor) : base(optionsAccessor)
    	{
    	}
    }
    
    public class MyController
    {
    	private readonly IDistributedCache _cache1;
    	private readonly IDistributedCache _cache2;
    
    	public MyController(IDistributedCache1 cache1, IDistributedCache2 cache2)
    	{
    		_cache1 = cache1;
    		_cache2 = cache2;
    	}
    }
    //	Bootstrapping
    
    services.AddOptions();
    
    services.Configure<RedisCacheOptions1>(config =>
    {
    	config.Configuration = Configuration.GetConnectionString("RedisCacheConnection1");
    	config.InstanceName = "MYINSTANCE1";
    });
    services.Configure<RedisCacheOptions2>(config =>
    {
    	config.Configuration = Configuration.GetConnectionString("RedisCacheConnection2");
    	config.InstanceName = "MYINSTANCE2";
    });
    
    services.Add(ServiceDescriptor.Singleton<IDistributedCache1, RedisCache1>());
    services.Add(ServiceDescriptor.Singleton<IDistributedCache2, RedisCache2>());
