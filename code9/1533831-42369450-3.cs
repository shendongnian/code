    public class StructuredUrlTester : IStructuredUrlTester {
        // Expose public getters for parts of the uri.Host value
        bool MyBooleanProperty { get; private set; }
    
        public StructuredUrlTester(IUriProvider provider) {
            Uri uri = provider.Current;
            // Test the value of uri.Host and extract parts via regex
        }
    }
