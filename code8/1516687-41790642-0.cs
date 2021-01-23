    static void WriteDirectoriesInternal(Stack<string> stack)
    {
        while (stack.Count > 0)
        {
            var currDir = stack.Pop();
            Console.WriteLine(currDir);
    
            foreach (var item in Directory.GetDirectories(currDir))
                stack.Push(item);
        }
    }
    
    static void WriteDirectories(string path)
    {
        Stack<string> directoryStack = new Stack<string>();
        directoryStack.Push(path);
        WriteDirectoriesInternal(directoryStack);
    }
    
    public static void Main(String[] args)
    {
        WriteDirectories("D:\\Program Files (x86)");
    
        Console.ReadLine();
    }
