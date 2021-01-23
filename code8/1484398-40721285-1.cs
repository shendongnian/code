    public static class WorkingEnvironmentExtensions
    {
        public static bool IsLocal(this IWorkingEnvironment environment)
        {    
            return environment.EnvironmentName == EnvironmentNames.Local;
        }
        public static bool IsDev(this IWorkingEnvironment environment)
        {    
            return environment.EnvironmentName == EnvironmentNames.Dev;
        }
        // etc...
    }
