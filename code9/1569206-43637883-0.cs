    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(cleanString("abc-def-c?p=2&x=5&z=6"));
    
                Console.WriteLine(cleanString("abc-def-c?"));
    
                Console.ReadLine();
            }
            public static string cleanString(string input)
            {
                if(input.Contains("p=") && input.Contains("&"))
                {
                    int startPos = input.IndexOf("p=");
                    int endPos = input.IndexOf("&",startPos);
                    input = input.Substring(0,startPos)+input.Substring(endPos+1,(input.Length-1)-endPos);
                }
    
                return input;
            }
        }
    }
