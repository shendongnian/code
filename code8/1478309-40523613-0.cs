    using System.Collections.Generic;
    using System.Linq;
    
    namespace Test
    {
        public class Program
        {
            private static void Main(string[] args)
            {
                var delays = new List<int> { 600, 300, 240, 60 }; // List with delays
                delays.ForEach(delay => StartProgram(delay));
            }
    
    
            public static void StartProgram(int delay)
            {
                SnapsEngine.SpeakString("{0} minutes remaining", delay / 60);
                SnapsEngine.Delay(delay);
            }
        }
    }
