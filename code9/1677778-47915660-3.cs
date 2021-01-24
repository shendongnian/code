    static void Main(string[] args)
    {
        //test out random string
        string input = "im the contents of a file";
        //convert input string to Sha1
        string result = ConvertToSha1(input);
        Console.WriteLine(input);
        Console.WriteLine(result);
        Console.WriteLine("------------");
        //test out longer string
        input = "im the contents of a file asdkjaskldjaskljdaskljdklasjdklasjdklasjdklasjdklasjdklasjdklajsdklajskldjaskldjaskldjaskldjaskljdaklsjdaklsjdklasjdkl";
        result = ConvertToSha1(input);
        Console.WriteLine(input);
        Console.WriteLine(result);
        Console.WriteLine("------------"); ;
        //test out file string
        //This will search the bin folder for a text file named this
        string path = "../SomeRandomTextFile.txt";
        //store the file into a string
        string readText = File.ReadAllText(path);
        Console.WriteLine(readText);
        
        //convert to sha1
        result = ConvertToSha1(readText);
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
