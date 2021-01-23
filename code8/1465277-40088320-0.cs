    class Program
    {
        static void Main(string[] args)
        {
            string action1 = "05/10/2016 15:23:42- UTC--test";
            string action2 = "05/10/2016 16:07:04- UTC--test";
            string action3 = "05/10/2016 16:33:54- UTC--test";
            string action4 = "06/10/2016 08:24:52- UTC--test";
            List<string> sample_actions = new List<string>() { action1, action2, action3, action4 };
            Record rec = new Record();
            foreach (string sample_action in sample_actions)
            {
                rec.Actions.AppendLine(sample_action).AppendLine();
            }
        }
    }
    class Record
    {
        public StringBuilder Actions { get; set; }
        public Record()
        {
            Actions = new StringBuilder();
        }
    }
