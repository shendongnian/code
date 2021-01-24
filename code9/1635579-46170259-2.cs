        [Flags]
        enum Colour
        {
            Black = 1,
            Blue = 785,
            Green = 4,
            Yellow = 666
        }
        
        static void Main(string[] args)
        {
            var isValid = Enum.IsDefined(typeof(Colour), 666); // true
            var isValid2 = Enum.IsDefined(typeof(Colour), 785); // true
            var isValid3 = Enum.IsDefined(typeof(Colour), 5); // false
        }
