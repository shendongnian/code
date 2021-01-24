    static void Main(string[] args)
    {
        string input = "im the contents of a file";
        string result = ConvertToSha1(input);
        Console.WriteLine(input);
        Console.WriteLine(result);
        Console.WriteLine("------------");
        input = "im the contents of a file asdkjaskldjaskljdaskljdklasjdklasjdklasjdklasjdklasjdklasjdklajsdklajskldjaskldjaskldjaskldjaskljdaklsjdaklsjdklasjdkl";
        result = ConvertToSha1(input);
        Console.WriteLine(input);
        Console.WriteLine(result);
        Console.WriteLine("------------"); ;
        //This will search the bin folder for a text file named this
        string path = "../SomeRandomTextFile.txt";
        // Open the file to read from.
        string readText = File.ReadAllText(path);
        Console.WriteLine(readText);
        result = ConvertToSha1(input);
        Console.WriteLine("\n\n Converted to Sha1 \n\n {0}", result);
        Console.ReadLine();
    }
    public static string ConvertToSha1(string input)
    {
        SHA1 sha = new SHA1CryptoServiceProvider();
        byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
        string result = BitConverter.ToString(bytes).Replace("-", "");
        return result;
    }
