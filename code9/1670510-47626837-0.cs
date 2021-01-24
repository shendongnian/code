    public class SplitData
    {
        public string Message1 { get; set; }
        public string Message2 { get; set; }
    }
    public class RemoteData
    {
        private SplitData _SplitData;
        public RemoteData(string Message)
        {
            this.Message = Message;
            if (IsValidMessage(this.Message))
            {
                _SplitData = new SplitData
                {
                    Message1 = Message.Split(':')[0].ToString(),
                    Message2 = Message.Split(':')[1].ToString()
                };
            }
        }
        public string Message { get; }
        public SplitData SplitData
        {
            get
            {
                return _SplitData;
            }
            set
            {
                _SplitData = value;
            }
        }
        private static bool IsValidMessage(string value)
        {
            const string expression = (@"([\w]+):([\w]+)");
            return Regex.IsMatch(value, expression, RegexOptions.IgnoreCase);
        }
    }
