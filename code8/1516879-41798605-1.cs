    public class Program
    {
        public static void Main()
        {
            var version = Microsoft
                .Extensions
                .PlatformAbstractions
                .PlatformServices
                .Default
                .Application
                .ApplicationVersion;
    
            System.Console.WriteLine("Version: {0}", version); // Version: 1.1.0.0
        }
    }
