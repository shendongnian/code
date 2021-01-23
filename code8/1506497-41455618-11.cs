    class Program
    {
        public class Exam
        {
            public string IDAFrom { get; set; }
            public string IDATo { get; set; }
        }
    
        public static string GetDateTime(string value)
        {
            DateTime date;
            string dateString = ""; // Empty by default
    
            // If full date is given, this will succeed
            if (DateTime.TryParse(value, out date))
            {
                dateString = date.ToShortDateString();
            }
            // If only year is given then this will succeed
            else if (DateTime.TryParseExact(value,
                    "yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out date))
            {
                dateString = date.ToShortDateString();
            }
    
            return dateString;
        }
    
        static void Main(string[] args)
        {
    
            var list = new List<Exam> { new Exam { IDAFrom = "1999", IDATo = null },
            new Exam { IDAFrom = DateTime.Now.ToShortDateString(), IDATo = DateTime.Now.AddDays(5).ToShortDateString() } };
            int i = 0;
            int j = 0;
            var rows = list.Select(exam =>
            {
    
                string inclusiveDates = string.Format("{0} - {1}", GetDateTime(exam.IDAFrom), GetDateTime(exam.IDATo));
                return new
                {
                    Id = ++i,
                    Cell = new object[] { ++j, inclusiveDates }
                };
            })
            .ToList();
    
    
            foreach (var item in rows)
            {
                Console.WriteLine("{0}\t{1}\t{2}", item.Id.ToString(), item.Cell[0], item.Cell[1]);
            }
            Console.Read();
    
        }
    }
