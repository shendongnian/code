    // Let's assume the class is static this time
    public static class FancyClass
    { [...] }
    public class MyAwesomeExtension : IDisposable
    {
        public MyAwesomeExtension()
        {
            // Override SaveAsync with custom logic
            FancyClass.SaveAsync = Save;
        }
        public async Task Save()
        {
            // Do something, might throw if in disposed state
        }
        // Implement IDisposable
    }
    public class SomeOtherClass
    {
        public async Task SaveAllChanges()
        {
            await FancyClass.SaveAsync().ConfigureAwait(false);
        }
    }
