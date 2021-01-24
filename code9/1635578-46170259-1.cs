        [Flags]
        enum Colour
        {
            Black = 1,  // 0001
            Blue = 2,   // 0010
            Green = 4,  // 0100
            Yellow = 8  // 1000
        }
        
        static void Main(string[] args)
        {
            var isValid = Enum.IsDefined(typeof(Colour), 5); // 5 is 0101
        }
