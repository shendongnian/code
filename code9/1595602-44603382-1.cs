    public class Weapon
    {
        public string name { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
    }
    public IEnumerable<Weapon> Weapons = new List<Weapon> 
    {
       new Weapon { name = "AK47AquamarineRevengeFieldTestet", price = .., quantity = ..},
       new Weapon { name = "AK47AquamarineRevengeMinimalWar", price = .., quantity = ..}, ...
    }
