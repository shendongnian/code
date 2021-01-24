    public static BuildCredentials GetGitHubCredentials(ICakeContext context)
    {
        return new BuildCredentials(
            context.EnvironmentVariable("CAKE_GITHUB_USERNAME"),
            context.EnvironmentVariable("CAKE_GITHUB_PASSWORD"));
    }
