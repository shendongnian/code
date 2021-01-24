    public static bool Compile(string[] sources, string output, params string[] references)
    {
        var results = CompileCsharpSource(sources, "result.exe", references);
        if (results.Errors.Count == 0)
                return true;
        else
        {
            foreach (CompilerError error in results.Errors)
                Console.WriteLine(error.Line + ": " + error.ErrorText);
        }
        return false;
    }
