    string result = "";
    string inputString = "This is paragraph.";
    for (int i = inputString.Length - 1; i >= 0; i--)
    {
        result += inputString[i];
    }
    Console.WriteLine(result);
    Console.ReadLine();
