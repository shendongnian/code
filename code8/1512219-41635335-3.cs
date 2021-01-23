    public class Item
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Cost { get; set; }
        public int Modifier { get; set; }
        public static Item CreatePotionAT()
        {
            return new Item
            {
               Name = "AT Potion",
               Desc = "Restores HP by 10.",
               Cost = 8,
               Modifier = 10
            };
        }
        // etc
    }
