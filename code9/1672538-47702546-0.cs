    using System;
    using NodaTime;
    using NodaTime.Text;
    
    class Program
    {
        static void Main()
        {
            string text = "26h44m3s";
            var pattern = DurationPattern.CreateWithInvariantCulture("H'h'm'm's's'");
            var duration = pattern.Parse(text).Value;
            Console.WriteLine(duration);
            var ts = duration.ToTimeSpan();
            Console.WriteLine(ts);
        }
    }
