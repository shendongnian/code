    class SimpleClass
        {
            public string someText { get; set; }
        }
    
        static void Main()
        {
            var cache = MemoryCache.Default;
            var simpleObject = new SimpleClass { someText = "starting text" };
            SimpleClass cachedContent = null;
    
            CacheItemPolicy policy = new CacheItemPolicy();
    
            cache.Add("mykey", simpleObject, policy);
    
            // Expect "starting text" output
            cachedContent = (SimpleClass) cache.Get("mykey");
            Console.WriteLine(cachedContent.someText);
    
            simpleObject.someText = "new text";
    
            // Now it will output "new text"
            cachedContent = (SimpleClass)cache.Get("mykey");
            Console.WriteLine(cachedContent.someText);
    
            // Now it will still output "new text"
            simpleObject = null;
            cachedContent = (SimpleClass)cache.Get("mykey");
            Console.WriteLine(cachedContent.someText);
        }
