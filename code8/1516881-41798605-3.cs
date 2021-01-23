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
    
            System.Console.WriteLine(version); // 5.4.3.2
        }
    }
