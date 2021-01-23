    class Program
    {
    	static void Main(string[] args)
    	{
    		Launcher.Start(@"C:\Users\Admin\path\to\your\console\app.exe");
    	}
    }    
    
    public class Launcher : MarshalByRefObject
    {
    	public static void Start(string pathToAssembly)
    	{
    		TextWriter originalConsoleOutput = Console.Out;
    		StringWriter writer = new StringWriter();
    		Console.SetOut(writer);
    
    		AppDomain appDomain = AppDomain.CreateDomain("Loading Domain");
    		Launcher program = (Launcher)appDomain.CreateInstanceAndUnwrap(
    			typeof(Launcher).Assembly.FullName,
    			typeof(Launcher).FullName);
    
    		program.Execute(pathToAssembly);
    		AppDomain.Unload(appDomain);
    
    		Console.SetOut(originalConsoleOutput);
    		string result = writer.ToString();
    		Console.WriteLine(result);
    	}
    
    	/// <summary>
    	/// This gets executed in the temporary appdomain.
    	/// No error handling to simplify demo.
    	/// </summary>
    	public void Execute(string pathToAssembly)
    	{
    		// load the bytes and run Main() using reflection
    		// working with bytes is useful if the assembly doesn't come from disk
    		byte[] bytes = File.ReadAllBytes(pathToAssembly); //"Program.exe"
    		Assembly assembly = Assembly.Load(bytes);
    		MethodInfo main = assembly.EntryPoint;
    		main.Invoke(null, new object[] { null });
    	}
    }
