    public class Item
    {
        public string Name { get; }
        public string Desc { get; }
        public int Cost { get; }
        public int Modifier { get; }
        public Item(string name, string desc, int cost, int modifier)
        {
            Name = name;
            Desc = desc;
            Cost = cost;
            Modifier = modifier;
        }
        public static Item CreatePotionHP()
        {
            return new Item("HP Potion","Restores HP by 10.", 8, 10);
        }
        // etc
    }
