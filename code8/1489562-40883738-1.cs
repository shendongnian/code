    public class DummySource
    {
        public string Detail { get; set; }
    }
    public class ImmutableDetail
    {
        public static ImmutableDetail Create(string detail) { return new ImmutableDetail(detail); }
        private ImmutableDetail(string detail)
        {
            Detail = detail;
        }
        public string Detail { get; private set; }
    }
