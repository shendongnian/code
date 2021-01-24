    /// <summary>
    /// RetryDynamicAttribute may be applied to test case in order
    /// to run it multiple times based on app setting.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class RetryDynamicAttribute : RetryAttribute {
        private const int DEFAULT_TRIES = 1;
        private int numberOfRetries = 0;
        public RetryDynamicAttribute(): 
            base(int.TryParse(ConfigurationManager.AppSettings["retryTest"], out numberOfRetries) ? numberOfRetries : DEFAULT_TRIES) { 
        }
    
    }
