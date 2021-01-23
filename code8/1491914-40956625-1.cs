    static void Main(string[] args)
    {
        double centimeter, liters, kilometer, kilogram;
        var converters = new Dictionary<char, IConverter>
        {
            { 'i', new CentimeterConverter() },
            { 'g', new LitersConverter() }
        }
        WriteLine("Enter the value you wanted to convert: ");
        int input = ToInt32(ReadLine());
        var choiceText = 
            "Press Any Of The Given Choices
             I->convert from inches to centimeters.
             G->convert from gallons to liters.
             M->convert from mile to kilometer.
             P->convert from pound to kilogram.";
        WriteLine(choiceText);
        char choice = Char.ToLower(ToChar(ReadLine()));
        var converter = converters[choice];
        WriteLine(converter.Convert(input));
        ReadKey();
    }
