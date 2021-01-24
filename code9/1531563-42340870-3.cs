    public static class WebHookConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.InitializeReceiveGitHubWebHooks(); // change this
        }
    }
