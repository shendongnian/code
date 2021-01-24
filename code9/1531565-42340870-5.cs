    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ...
            // Load receivers
            config.InitializeReceiveGitHubWebHooks();
        }
    }
