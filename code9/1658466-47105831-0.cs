    namespace ELMFS
    {
        public class ReadFromCSV
        {
            static List<TextSpeak> ReadCSV(string[] args)
            {
                List<TextSpeak> TxtSpk = File.ReadAllLines(@"C:\textwords.csv")
                    .Skip(1)
                    .Select(t => TextSpeak.FromCsv(t))
                    .ToList();
                return TxtSpk;
            }
        }
        public class TextSpeak
        {
            public string Abreviated { get; private set; }
            public string Expanded { get; private set; }
            public static TextSpeak FromCsv(string csvLine)
            {
                string[] TxtSpk = csvLine.Split(',');
                TextSpeak textSpeak = new TextSpeak();
                textSpeak.Abreviated = TxtSpk[0];
                textSpeak.Expanded = TxtSpk[1];
                return textSpeak;
            }
        }
    }
