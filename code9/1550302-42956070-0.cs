    public static class SchedulerHttpClient
    {
      ... // Same as above, but making MainAsync private.
      public static readonly Lazy<Task> Initialize = new Lazy<Task>(() => MainAsync());
    }
