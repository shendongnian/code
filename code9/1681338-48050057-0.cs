    public class StubDateTimeProvider : IDateTimeProvider
    {
        public StubDateTimeProvider(DateTime value)
        {
            this.Value = value;
        }
        public DateTime Value { get; }
        public DateTime Now()
        {
            return this.Value;
        }
    }
