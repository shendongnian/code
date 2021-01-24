    class Program
    {
        static void Main()
        {
            Go.Run();
        }
    }
    [Command("do-stuff")]
    [Description("I've no idea what we're doing")]
    public class WhiteRussian : ICommand
    {
        [Parameter("Source")]
        public double Source { get; set; }
        [Parameter("Destination")]
        public double Destination { get; set; }
    
        public void Run()
        {
            // Do stuff with Source and Destination.
        }
    }
