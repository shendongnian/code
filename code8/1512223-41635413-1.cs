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
        Name = "HP Potion";
        Desc = "Restores HP by 10.";
        Cost = 8;
        Modifier = 10;
    }
    public class PotionAT : Item
    {
       // Specific Attributes
       Name = "AT Potion";
       Desc = "Restores Attack by 1.";
       Cost = 8;
       Modifier = 10;
    }
       public class Revive : Item
    {
        // Specific Attributes
        Name = "Revive";
        Desc = "Revives upon death with 5 HP.";
        Cost = 8;
        Modifier = 10;
    }
