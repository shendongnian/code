    using System;
    
    class Test
    {
        static void Main()
        {
            float totalSeconds = 228.10803f;
            TimeSpan time = TimeSpan.FromSeconds(totalSeconds);
            Console.WriteLine(time.ToString("hh':'mm':'ss")); // 00:03:48
        }
    }
