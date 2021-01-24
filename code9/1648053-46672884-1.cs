    public class DynamicOutputCacheAttribute : OutputCacheAttribute
    {
        public DynamicOutputCacheAttribute()
        {
            if (GlobalVariables.IsDebuggingEnabled)
            {
                this.VaryByParam = "*";
                this.Duration = 0;
                this.NoStore = true;
            }
        }
    }
