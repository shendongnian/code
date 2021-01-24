    static void Main(string[] args)
    {
        string FirstString = "??(?131?|?26?)??";
    
        var parts = FirstString.Split('|');
        
        Console.WriteLine(ExtractNumber(parts[0]));
        Console.WriteLine(ExtractNumber(parts[1]));
                
        Console.ReadLine();
        Console.ReadLine();
    }
    
    private static int ExtractNumber(string text)
    {
        var numberString = String.Join("", text.Where(Char.IsNumber));
        int result = 0;
        int.TryParse(numberString, out result);
        return result;
    }
