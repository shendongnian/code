	static void Main(String[] args)
    {
        var myInput = "5000123456789001, 5000-1234-5678-9001, 5000 1234 5678 9001, 50001234567890010000, 5000-1234-5678-9001-0000, 5000 1234 5678 9001 0000, 5000-1234-5678-90010-000, 5000 1234 5678 90010 000";
        foreach (var cardNumber in SeparateInput(myInput, ','))
        {
            Console.WriteLine($"'{cardNumber}' is {(IsThisNumberValid(cardNumber) ? "valid" : "not valid" )}");
        }
        Console.ReadLine();
    }
    private static bool IsThisNumberValid(string input)
    {
        return Regex.IsMatch(input, @"^(?:\d[ -]*?){13,16}$");
    }
    private static IEnumerable<string> SeparateInput(string input, char separator)
    {
        foreach (var splitted in input.Split(new []{separator}, StringSplitOptions.RemoveEmptyEntries))
        {
            yield return splitted.Trim();
        }
    }
