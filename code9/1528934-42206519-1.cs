    private static readonly Policy syncPolicy = Policy.Handle<Exception>().WaitAndRetry(5, _ => TimeSpan.FromSeconds(1));
    private static readonly Policy asyncPolicy = Policy.Handle<Exception>().WaitAndRetryAsync(5, _ => TimeSpan.FromSeconds(1));
    public static async Task TrySetPropertyAsync(GraphObject user, string propertyName, string value)
    {
      await asyncPolicy.ExecuteAsync(() => GraphClient.SetExtendedPropertyAsync(user, propertyName, value));
    }
    public static void TrySetProperty(GraphObject user, string propertyName, string value)
    {
      syncPolicy.Execute(() => GraphClient.SetExtendedProperty(user, propertyName, value));
    }
