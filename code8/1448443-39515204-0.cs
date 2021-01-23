    var inputCollection = new List<int> { 40, 60, 80, 100 };
    var binaryStringBuilder = new StringBuilder();
    foreach (var input in inputCollection)
    {
        binaryStringBuilder.Append(input == default(int) ? 0 : 1);
    }
    
    var binaryRepresentation = binaryStringBuilder.ToString();
    var decimalRepresentation = Convert.ToInt32(binaryRepresentation, 2).ToString();
    Console.WriteLine("Binary representation: {0}", binaryRepresentation);
    Console.WriteLine("Decimal representation: {0}", decimalRepresentation);
