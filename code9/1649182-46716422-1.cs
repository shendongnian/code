    public class NumberReader
    {
        public HashSet<string> Numbers { get; set; }
        // Numbers instantiated in constructor
        public NumberReader()
        {
            Numbers = new HashSet<string>();
        }
        // Executed when user click a button
        public async Task Read()
        {
            var number = await ScanCodeVm.CodePage();
            if (number != null)
            {
                Numbers.Add(number);
            }
        }
    }
