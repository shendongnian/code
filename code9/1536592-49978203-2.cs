     public IActionResult CacheTryGetValueSet()
        {
            var list = GetOrSet(CacheKeysWithOption.Entry, GetStringList);
            return new JsonResult(list);
        }
        [NonAction]
        public List<String> GetStringList()
        {
            List<String> str = new List<string>()
            {
                "aaaaa",
                "sssdasdas",
                "dasdasdas"
            };
            return str;
        }
