     public T CacheIt<T>(object container,string methodName,params object[] parameterlist)
        {
            MethodInfo func = container.GetType().GetMethod(methodName);
            var cache = MemoryCache.Default;
            T value = (T)cache.Get(func.Name);
            if(value!=null)
            {
                return value;
            }
            value = (T)func.Invoke(container,parameterlist);
            cache.Add(func.Name, value,new CacheItemPolicy());
            return value;
        }
        public void PrintUserName()
        {
         CacheIt<string>(this,nameof(this.GetUserName),"1");
            CacheIt<string>(this, nameof(this.GetFullName), "Raghu","Ram");
            Console.Read();
        }
        public string GetUserName(string userId)
        {
            // how can I pass the method as parameter? 
            // Method is dynamic and can be any method with parameter(s) and return value
            //return CacheIt<string>(item => GetUserNameFromDb(userId));
            return $"UserId : {userId} & UserName:Vaishali";
        }
        public string GetFullName(string FirstName,string  LastName)
        {
            return $"FullName : {string.Concat(FirstName," ",LastName)}";
        }
