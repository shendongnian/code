    private static readonly Policy syncPolicy = Policy.Handle<Exception>().WaitAndRetry(5, _ => TimeSpan.FromSeconds(1));
    private static readonly Policy asyncPolicy = Policy.Handle<Exception>().WaitAndRetryAsync(5, _ => TimeSpan.FromSeconds(1));
    private static async Task TrySetProperty(GraphObject user, string propertyName, string value, bool sync)
    {
        if (sync)
            syncPolicy.Execute(() => GraphClient.SetExtendedProperty(user, propertyName, value));
        else
            await asyncPolicy.ExecuteAsync(() => GraphClient.SetExtendedPropertyAsync(user, propertyName, value));
    }
    public static Task TrySetPropertyAsync(GraphObject user, string propertyName, string value) =>
        TrySetProperty(user, propertyName, value, sync: false);
    public static void TrySetProperty(GraphObject user, string propertyName, string value) =>
        TrySetProperty(user, propertyName, value, sync: true).GetAwaiter().GetResult();
