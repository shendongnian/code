    static string GetFriendlyTypeName<T>()
    {
        var csharpCodeProvider = new Microsoft.CSharp.CSharpCodeProvider();
        var codeType = new System.CodeDom.CodeTypeReference(typeof(T));
        return csharpCodeProvider.GetTypeOutput(codeType);
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine(GetFriendlyTypeName<Int32>()); //int
        Console.WriteLine(GetFriendlyTypeName<UInt32>()); //unit
    }
