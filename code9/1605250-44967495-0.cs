    public class Boodschappenlijst
    {
        public static string[] producten { get; set; } = new string[] { "Peper", "Zout", "Kruidnagel", "Sla", "Komkommer", "Tomaten", "Tandpasta", "Shampoo", "Wax", "Deodorant" };
        private List<string> Items { get; set; }
        public Boodschappenlijst(List<string> items)// << Constructor
        {
            Items = items;
        }
    }
