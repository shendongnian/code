    public class MyApp
    {
        private readonly Dictionary<string, Action> _commands = new Dictionary<string, Action>();
    
        public static void Main()
        {
            var program = new MyApp();
            // Run Console Stuff
        }
    
        public MyApp()
        {
            SetupCommands();
        }
    
        public void SetupCommands()
        {
            _commands.Add("PrintDate", () => Console.WriteLine(DateTime.Now));
            _commands.Add("PrintMaxOf3And7", () => Console.WriteLine(Math.Max(3, 7)));
        }
    
        public void ExecuteCommand(string commandName)
        {
            _commands[commandName].Invoke();
        }
    }
