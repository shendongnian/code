    // an extension method to check if a string is all decimal digits
    public static class StringHelper {
        public static bool IsNumeric(this string str)
        {
            if (str.IsNullOrEmpty() || str.IsNullOrWhiteSpace()) return false;
            return str.All(char.IsNumber);
        }
    }
    ...
    
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a string...");
        string delimeter = " ";
        string input = Console.ReadLine();
        string[] output = input.Split(Convert.ToChar(delimeter));
    
        foreach (var substring in output)
        {               
            if (substring.IsNumeric())
            {
                substring = (int.Parse(substring) * 2).ToString();
            }
            Console.Write(substring);
        }
        Console.WriteLine();
        Console.Read();
    }
