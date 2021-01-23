    public class Item
    {
        public string Name = "HP Potion";
        public string Desc = "Restores HP by 10.";
        public int Cost = 8;
        public int Modifier = 10;
        //All Item Attributes
    }
    public class PotionHP : Item
    {
        // Specific Attributes
        string Name = "HP Potion";
        string Desc = "Restores HP by 10.";
        int Cost = 8;
        int Modifier = 10;
    }
    public class PotionAT : Item
    {
       // Specific Attributes
       string Name = "AT Potion";
       string Desc = "Restores Attack by 1.";
       int Cost = 8;
       int Modifier = 10;
    }
       public class Revive : Item
    {
        // Specific Attributes
        string Name = "Revive";
        string Desc = "Revives upon death with 5 HP.";
        int Cost = 8;
        int Modifier = 10;
    }
