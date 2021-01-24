    public static class CacheConfig
    {
        public static int Duration = 36600;
    }
    
    public class MyOutputCacheAttribute : OutputCacheAttribute
    {
        public MyOutputCacheAttribute()
        {
            this.Duration = CacheConfig.Duration;
        }
    }
    
    [MyOutputCache(VaryByParam = "none")]
    public ActionResult Index()
    {
        return View();
    }
