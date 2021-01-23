    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var filename = Path.Combine(path, "WindowsFormsApplication1.exe");
            var assembly = Assembly.LoadFile(filename);
            var programType = assembly.GetTypes().FirstOrDefault(c => c.Name == "Program"); // <-- if you don't know the full namespace and when it is unique.
            var method = programType.GetMethod("Start", BindingFlags.Public | BindingFlags.Static);
            method.Invoke(null, new object[] { });
        }
    }
