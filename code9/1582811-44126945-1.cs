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
                string outWardResult = finalPostcode.Substring(0, finalPostcode.Length - 3);
                string inWardResult = finalPostcode.Substring(Math.Max(0, finalPostcode.Length - 3));
                string postCodeResult = string.Format("{0} {1}", outWardResult, inWardResult);
                finalPostcode = postCodeResult;
    
                return finalPostcode;
            }
        }
    }
