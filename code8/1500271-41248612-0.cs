    static void Main(string[] args)
    {
        string[] lines = new string[] {
            "\"12/19/2016 11:13:30 AM\",Error Recovery Histogram: 81920 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 ",
            "\"12/19/2016 11:13:30 AM\",Failed Bit Histogram: 3187 78228 469 36 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0"
        };
        var timestampDelimiters = new string[] { "," };
        var msgDelimiters = new string[] { ":" };
        var numberDelimiters = new string[] { " " };
        foreach (var line in lines)
        {
            var msgTokens = line.Split(timestampDelimiters, System.StringSplitOptions.None);
            string timestamp = msgTokens[0];
            string message = msgTokens[1];
            var histTokens = message.Split(msgDelimiters, System.StringSplitOptions.None);
            string histogramTitle = histTokens[0];
            string histogramValues = histTokens[1];
            var entries = histogramValues.Split(numberDelimiters, System.StringSplitOptions.RemoveEmptyEntries);
            var numbersList = new System.Collections.Generic.List<int>();
            //Iterate through entries and convert them
            foreach (var entry in entries)
            {
                numbersList.Add(System.Convert.ToInt32(entry));
            }
            // Use it like a List, or convert it to an array with ToArray method
            System.Console.Write("{0}: {1} entries", histogramTitle, numbersList.ToArray().Length);
        }
        
        System.Console.ReadKey();
    }
