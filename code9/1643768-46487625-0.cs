     class Program
    {
        static void Main(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            List<Entry> entries = new List<Entry>();
            entries.Add(new Entry()
            {
                App = "MyApp.exe",
                Value = "0x1234567A"
            });
            entries.Add(new Entry()
            {
                App = "MyOtherApp.exe",
                Value = "0x1234567B"
            });
            foreach (Entry entry in entries)
            {
                //append multiple tabs here - the longer your appname is.
                builder.AppendLine(string.Format("{0}\t{1}", entry.App, entry.Value));
            }
            Console.Write(builder.ToString());
            Console.ReadLine();
        }
    }
    class Entry
    {
        public string App { get; set; }
        public string Value { get; set; }
    }
