        public static IEnumerable<string> generate()
        {
            long n = -1;
            while (true) yield return toBase26(++n);
        }
       
        public static string toBase26(long i)
        {
            if (i == 0) return ""; i--;
            return toBase26(i / 26) + (char)('A' + i % 26);
        }
        
        public static void BuildQuery()
        {
            IEnumerable<string> lstExcelCols = generate();
            try
            {
                string s = lstExcelCols.ElementAtOrDefault(1) ;
            }
            catch (Exception exc)
            {
               
            }
        }
