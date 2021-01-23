    class Program
    {
        static void Main(string[] args)
        {
            var escaped   = @"def s_CalculatePartiallyUsedTechPenalty(rate):\n    total = min(rate,0)\n    title = \""Partially Used Technology Penalty\"" \n    return RateItem(title,total,FinancialUniqueCode.PartiallyUsedTechPenalty,False)";
            var unescaped = Regex.Unescape(escaped);
    
            Console.WriteLine(unescaped);
        }
    }
