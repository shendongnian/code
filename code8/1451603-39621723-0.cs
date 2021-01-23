    public class DataCls
    {
        public string Message { get; set; }
        public string Priority { get; set; }
        public DateTime Time { get; set; }
        public string Tag { get; set; }
        public void ProcessMessage(string message)
        {
            var indexMessage = message.IndexOf("Message");
            var indexPriority = message.IndexOf("Priority");
            var indexTime = message.IndexOf("Time");
            var indexTag = message.IndexOf("Tag");
            this.Message = message.Substring(indexMessage + 8, indexPriority - indexMessage - 9);
            this.Priority = message.Substring(indexPriority + 9, indexTime - indexPriority - 10);
            var time = message.Substring(indexTime + 5, indexTag - indexTime - 6);
            this.Time = DateTime.Parse(time);
            this.Tag = message.Substring(indexTag + 4, message.Length - indexTag-4);
        }
    }
