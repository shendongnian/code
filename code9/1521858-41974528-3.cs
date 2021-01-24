    Once some classes add, Your code can look like this:
    namespace WpfPromholComplementary_1
    {
        public class Module
        {
            public string Number { get; set; }
            public double Ch1 { get; set; }
            public double Ch2 { get; set; }
            public double Ch3 { get; set; }
            public double Ch4 { get; set; }
        }
        public class MainViewModel
        {
            public Module Module1 { get; set; } = new Module() { Number = "1", Ch1 = 123.4, Ch2 = 123.4, Ch3 = 123.4, Ch4 = 123.4 };
            public Module Module2 { get; set; } = new Module() { Number = "2", Ch1 = 123.4, Ch2 = 123.4, Ch3 = 123.4, Ch4 = 123.4 };
            public Module Module3 { get; set; } = new Module() { Number = "3", Ch1 = 123.4, Ch2 = 123.4, Ch3 = 123.4, Ch4 = 123.4 };
            public Module Module4 { get; set; } = new Module() { Number = "4", Ch1 = 123.4, Ch2 = 123.4, Ch3 = 123.4, Ch4 = 123.4 };
            public Module Module5 { get; set; } = new Module() { Number = "5", Ch1 = 123.4, Ch2 = 123.4, Ch3 = 123.4, Ch4 = 123.4 };
            public Module Module6 { get; set; } = new Module() { Number = "6", Ch1 = 123.4, Ch2 = 123.4, Ch3 = 123.4, Ch4 = 123.4 };
        }
    }
    
