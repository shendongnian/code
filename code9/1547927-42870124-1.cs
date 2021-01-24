        static void Main(string[] args)
        { 
            var testVals = new[] {"Jan", "FEB", "mar", "bad"};
            foreach (var v in testVals)
            {
                DateTime dt;
                if (DateTime.TryParseExact(v.ToUpper(),
                    "MMM",
                    CultureInfo.CurrentCulture, // you may want new CultureInfo("en-US") if you intend only English values to pass.
                    DateTimeStyles.AssumeLocal,
                    out dt))
                    Console.WriteLine($"{v} returns {dt.Month}");
                else
                    Console.WriteLine($"{v} failed parsing.");
            }
            Console.ReadKey();
        }
