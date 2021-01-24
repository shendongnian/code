    public class Function
    {
        public string Handler(SNSEvent snsEvent)
        {
            foreach (var record in snsEvent.Records)
            {
                var snsRecord = record.Sns;
                Console.WriteLine($"[{record.EventSource} {snsRecord.Timestamp}] Message = {snsRecord.Message}");
            }
        }
    }
