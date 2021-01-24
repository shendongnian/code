    namespace UKPostCodeConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string firstPostCode = "DD81UN";
                string secondPostCode = "DN551PT";
                Console.WriteLine(ParseToUkPostcode(firstPostCode));
                Console.WriteLine(ParseToUkPostcode(secondPostCode));
                Console.Read();
            }
            public static string ParseToUkPostcode(string aPostcode)
            {
                string finalPostcode = aPostcode;
    
                finalPostcode = finalPostcode.Replace(" ", "").Trim();
                string outWard = finalPostcode.Substring(0, finalPostcode.Length - 3);
                string inWard = finalPostcode.Substring(Math.Max(0, finalPostcode.Length - 3));
                string postCode = string.Format("{0} {1}", outWard, inWard);
                finalPostcode = postCode;
    
                return finalPostcode;
            }
        }
    }
