    using System;
    using System.Linq;
    using NodaTime;
    using NodaTime.Text;
    
    class Program
    {
        static void Main()
        {
            
            string[] formats =
            {
                "H'h'm'm's's'", "H'h'm'm'", "M'm's's'", "H'h'", "M'm'", "S's'"
            };
            var patterns = formats.Select(DurationPattern.CreateWithInvariantCulture);
            var builder = new CompositePatternBuilder<Duration>();
            foreach (var pattern in patterns)
            {            
                // The second parameter is used to choose which pattern is
                // used for formatting. Let's ignore it for now.
                builder.Add(pattern, _ => true);
            }
            var composite = builder.Build();
            
            
            string[] values = { "26h8m", "26h", "15s", "56m47s" };
            foreach (var value in values)
            {
                Console.WriteLine(composite.Parse(value).Value);
            }
        }
    }
