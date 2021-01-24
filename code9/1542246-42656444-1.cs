    class Program
    {
        static void Main()
        {
            string text = " dasd arew 2017-03-11 12:25:56.345 Z 2017-03-11 12:25:56.345 Z das tfgwe 2017-03-11 12:25:56.345 Z";
            string pattern = @"\d{4}\-\d{2}\-\d{2}\s\d{2}\:\d{2}\:\d{2}\.\d{3}\sZ";
            Regex r = new Regex(pattern);
            var res = r.Replace(text, new MatchEvaluator(ConvertDateFormat));
            Console.WriteLine(res);
        }
        static string ConvertDateFormat(Match m)
        {
            var mydate = DateTime.Parse(m.Value);
            return mydate.ToString("yyyy-MM-dd hh:mm:ss");
        }
    }
