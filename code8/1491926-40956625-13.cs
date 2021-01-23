    static void Main(string[] args)
    {
        var converters = new ConverterCollection();
        var toCentimeters = new ConverterToContinentalUnit 
        { 
            Key = "i", 
            Coefficent = 0.3937, 
            PrefixForResult = "In Centimeters"
        }
        converters.Add(toCentimeters );
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
