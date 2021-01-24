    public static class EnvironmentExtensions {
        const string CloudDbEnvironment = "CloudDb";
        const string TestingEnvironment = "Testing";
        public static bool IsCloudDb(this IHostingEnvironment env) {
            return env.IsEnvironment(CloudDbEnvironment);
        }
        public static bool IsTesting(this IHostingEnvironment env) {
            return env.IsEnvironment(TestingEnvironment);
        }
    }
