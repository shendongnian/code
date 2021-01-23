    static void Main(string[] args)
    {
            Console.WriteLine("Enter a string...");
            string delimeter = " ";
            string input = Console.ReadLine();
            var result =  System.Text.RegularExpression.Regex.Replace(input,"\d+", match=>(int.Parse(match.Value)*2).ToString(CultureInfo.InvariantCul‌​ture));
            Console.WriteLine(result); 
             Console.Read();
    
    }
