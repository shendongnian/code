    namespace ConsoleApplication1
    {
        public class Program
        {
            public static void Main()
            {
                var defSettings = ConsoleApplication1.Properties.Settings.Default;
                var props = defSettings.Test = "Whatever";
    
                // Save it so it persists between application start-ups
                defSettings.Save();
    
                Console.Read();
            }
        }
    }
