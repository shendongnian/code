    private static int ExtractNumber(string text)
    {
       var numberString = String.Join("", text.Where(Char.IsNumber));
       int.TryParse(numberString, out var result);
       return result;
    }
