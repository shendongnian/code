    public class DateConverter : ConverterBase
    {
        public override object StringToField(string from)
        {
            //if you can't convert to date time.. .return null
            DateTime date;
            if (!DateTime.TryParse(from, out date))
            {
                ErrorTracker.Add(string.Format("Failed to parse date {0}.", from));
                return null;
            }
            return date;
        }
        /// etc...
    }
    public static class ErrorTracker
    {
        public static List<string> ErrorList = new List<string>();
        public static void Add(string errorMessage)
        {
            ErrorList.Add(errorMessage);
        }
        public static void Clear()
        {
            ErrorList.Clear();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new FileHelperEngine<ModelClass>();
            ErrorTracker.Clear();
            var productRecords = engine.ReadFile(@"C:\whatever.txt");
            foreach (var errorMessage in ErrorTracker.ErrorList)
            {
                Console.WriteLine(errorMessage);
            }
            Console.ReadKey();
        }
    }
