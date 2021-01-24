        public class RegisterViewModel
        {
            [Required]
            public Guid Id { get; set; }
            /* other properties here */
            ...
        }
    and then use `IMemoryCache` or `IDistributedMemoryCache` (see [ASP.NET Core Docs](https://docs.microsoft.com/en-us/aspnet/core/performance/caching/memory)) to put this Id into the memory cache and validate it on request
        public Task<IActioNResult> Register(RegisterViewModel register)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var userId = ...; /* get userId */
            if(_cache.TryGetValue($"Registration-{userId}", register.Id))
            {
                return BadRequest(new { ErrorMessage = "Command already recieved by this user" });
            }
            // Set cache options.
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Keep in cache for 5 minutes, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromMinutes(5));
            // when we're here, the command wasn't executed before, so we save the key in the cache
            _cache.Set($"Registration-{userId}", register.Id, cacheEntryOptions );
            // call your service here to process it
            registrationService.Register(...);
        }
    When the second request arrives, the value will already be in the (distributed) memory cache and the operation will fail.
    If the caller do not sets the Id, validation will fail.
