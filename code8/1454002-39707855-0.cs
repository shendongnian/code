    public class EmployeeFacade: CacheBase<IEnumerable<Employee>>
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeFacade(IEmployeeRepository employeeRepository) : base("3600","Employee_Cache",cacheConfigurationJSON)
        {
            _repository = employeeRepository;
        }
      public method GetEmployee(string organization, string department)
      {
            var groupKeyAndValues = new List<Tuple<string, string>>();
            groupKeyAndValues.Add(new Tuple<String, string>("Organization", organization));
            groupKeyAndValues.Add(new Tuple<String, string>("Department", department));
            bool isCacheAllowed;
            var employeeInfos = base.GetFromCache(() => _repository.GetEmployee(organization, department), groupKeyAndValues, out isCacheAllowed);
            //if cache is not allowed for this combination , return direct from repository.
            if (!isCacheAllowed)
                return _repository.GetEmployee(organization, department);
      }
    }
    public abstract class CacheBase<T> where T : class
    {
        private string _cacheTimeoutInSeconds;
        private string _cacheConfiguration;
        private static readonly object CacheLockObject = new object();
        string _cacheKey;
        public CacheBase(string cacheTimeoutInSeconds, string cacheKey, string cacheConfigurationJson)
        {
            _cacheTimeoutInSeconds= cacheTimeoutInSeconds;
            _cacheConfiguration = cacheConfigurationJson;
            _cacheKey = cacheKey;
        }
        public T GetFromCache(Func<T> methodToFillCache, IEnumerable<Tuple<string, string>> groupKeyAndValues, out bool isCacheAllowed)
        {
            var baseCacheKey = _cacheKey;
            var detailedCacheKey = GenerateCacheKey(groupKeyAndValues);
            isCacheAllowed = IsSaveToCacheAllowed(baseCacheKey, groupKeyAndValues);
            if (!isCacheAllowed) return null;
            var result = HttpRuntime.Cache[detailedCacheKey] as T;
            if (result == null)
            {
                lock (CacheLockObject)
                {
                    if (result == null)
                    {
                        result = methodToFillCache() as T;
                        SetToCache(result, detailedCacheKey);
                    }
                }
            }
            return result;
        }
        private void SetToCache(T data, string detailedCacheKey)
        {
            
            HttpRuntime.Cache.Insert(detailedCacheKey, data, null,
                DateTime.Now.AddSeconds(Convert.ToInt32(cacheTimeoutInSeconds)), TimeSpan.Zero);
        }
        private string GenerateCacheKey(IEnumerable<Tuple<string, string>> groupKeyAndValues)
        {
            string detailedCacheKey = _cacheKey;
            if (groupKeyAndValues == null) return detailedCacheKey;
            var groupKeys = groupKeyAndValues.Select(x => x.Item1).ToList();
            if (groupKeys != null && groupKeys.Count > 0)
            {
                foreach (var groupKey in groupKeys)
                {
                    if (!String.IsNullOrWhiteSpace(groupKey))
                        detailedCacheKey += "_" + groupKey;
                }
            }
            return detailedCacheKey;
        }
        private bool IsSaveToCacheAllowed(string cacheKey, IEnumerable<Tuple<string, string>> groupKeyAndValues)
        {
            cacheKey = cacheKey.ToUpper();
            
            if (_cacheConfiguration == null) return false;
            string valuesAllowed = CacheConstant.All; string valuesDenied = CacheConstant.All;
            //CACHE                                                                 
            if (_cacheConfiguration == null) return true;
            valuesAllowed = _cacheConfiguration.Allow;
            valuesDenied = _cacheConfiguration.Deny;
            var matchingCacheConfig = _cacheConfiguration.Keys.FirstOrDefault(x => x.Key.ToUpper() == cacheKey);
            if (matchingCacheConfig == null) return IsAllowed(cacheKey, valuesAllowed, valuesDenied); ;
            valuesAllowed = matchingCacheConfig.Allow;
            valuesDenied = matchingCacheConfig.Deny;
            bool isAllowed = IsAllowed(cacheKey, valuesAllowed, valuesDenied);                                                                               
            foreach (var groupKeyAndValue in groupKeyAndValues)
            {
                var key = groupKeyAndValue.Item1.ToUpper();
                var value = groupKeyAndValue.Item2.ToUpper();
                matchingCacheConfig = matchingCacheConfig.Keys.FirstOrDefault(x => x.Key.ToUpper() == key);
                if (matchingCacheConfig == null) return IsAllowed(key, valuesAllowed, valuesDenied);
                valuesAllowed = matchingCacheConfig.Allow;
                valuesDenied = matchingCacheConfig.Deny;
                isAllowed = IsAllowed(value, matchingCacheConfig.Allow, matchingCacheConfig.Deny);
                if (!isAllowed) break;
            }
            return isAllowed;
        }
        bool IsAllowed(string value, string allowedValues, string deniedValues)
        {
            //Prerequisites: among allowed and denied values , one should contain * and other should contain value or empty string 
            var allowed = allowedValues.ToUpper().Split(',');
            var denied = deniedValues.ToUpper().Split(',');
            if (denied.Contains(CacheConstant.All))
            {
                if (allowed.Contains(value) || allowed.Contains(CacheConstant.All))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (denied.Contains(value))
            {
                if (allowed.Contains(value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else //denied contains nothing
            {
                if (allowed.Contains(value) || allowed.Contains(CacheConstant.All) || allowed.Count() == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
    
