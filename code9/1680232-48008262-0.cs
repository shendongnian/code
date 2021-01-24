    static void Main()
    {
        var items = new List<Style>();
        items.Add(new Style { Name = "Array 0", Color = "#505050", Font = "Arial" });
    }
    public class Style
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Font { get; set; }
    }
