            var builder = new RecordBuilder()
                .RegisterBuilder("document", () => new Document())
                .RegisterBuilder("headlines", () => new Headlines());
            builder.Build(code);
    public class RecordBuilder
    {
        public Records Build(string code)
        {
            Func<Records> buildAction;
            if (recordBuilders.TryGetValue(code, out buildAction))
            {
                return buildAction();
            }
            return null;
        }
        public RecordBuilder RegisterBuilder(string code, Func<Records> buildAction)
        {
            recordBuilders.Add(code, buildAction);
            return this;
        }
        private Dictionary<string, Func<Records>> recordBuilders = new Dictionary<string, Func<Records>>();
    }
