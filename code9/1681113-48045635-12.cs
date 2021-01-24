    class NamedColor
    {
        public ConsoleColor Color { get; set; }
        public string Name { get; set; }
        public NamedColor(ConsoleColor color, string name)
        {
            Color = color;
            Name = name;
        }
    }
