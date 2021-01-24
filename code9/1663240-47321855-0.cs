        public  void CacheUser(AuthenticationResult ar)
        {
            JObject user = ParseIdToken(ar.IdToken);
            var cache = new CachedUsers
            {
                FullName = user["name"]?.ToString(),
                Email = user["emails"]?.FirstOrDefault()?.ToString()
            };
             BlobCache.LocalMachine.InsertObject("usercached", cache);
        }
