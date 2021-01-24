    public class Stat
    {
        public int level { get; set; }
        public int areaDamage { get; set; }
        public int crownTowerDamage { get; set; }
        public int? hitpoints { get; set; }
        public int? dps { get; set; }
    }
    
    public class RootObject
    {
        public string _id { get; set; }
        public string idName { get; set; }
        public string rarity { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int arena { get; set; }
        public int elixirCost { get; set; }
        public int order { get; set; }
        public int __v { get; set; }
        public int radius { get; set; }
        public string target { get; set; }
        public List<Stat> stats { get; set; }
        public string statsDate { get; set; }
        public int? hitSpeed { get; set; }
        public int? speed { get; set; }
        public int? deployTime { get; set; }
        public double? range { get; set; }
        public int? count { get; set; }
        public string transport { get; set; }
    }
