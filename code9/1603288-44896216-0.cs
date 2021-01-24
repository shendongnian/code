        static void Main(string[] args)
        {
            Dictionary<string, DateTime> variables = new Dictionary<string,     DateTime>();
            for (int i = 0; i <= 4; i++) {
                variables.Add(String.Format("CalculationTimeDown{0}", i.ToString("000")), DateTime.Now.AddMinutes(i * 30));
            }
        }
    }
