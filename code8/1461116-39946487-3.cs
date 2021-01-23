    public class CompletionDataRequest
    {
        public CompletionDataRequest(string text, int cursorPosition, string dataSource, string project)
        {
            Text = text;
            CursorPosition = cursorPosition;
            DataSource = dataSource;
            Project = project;
        }
        [JsonConstructor]
        private CompletionDataRequest()
        {
        }
        [JsonProperty]
        public string Text { get; private set; }
        [JsonProperty]
        public int CursorPosition { get; private set; }
        [JsonProperty]
        public string DataSource { get; private set; }
        [JsonProperty]
        public string Project { get; private set; }
    }
