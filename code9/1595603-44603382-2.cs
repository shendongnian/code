    public class Weapon
    {
        public int price { get; set; }
        public int quantity { get; set; }
    }
    public class AK47AquamarineRevengeFieldTested : Weapon
    {
    }
    public class AK47AquamarineRevengeMinimalWear : Weapon
    {
    }
    // etc., do this for each AK... class
    
    public class Response
    {
        public Weapon AK47AquamarineRevengeFieldTested { get; set; }
        public Weapon AK47AquamarineRevengeMinimalWar { get; set; }
        // Add all those weapons here, or use (you need a different JSON result though)
        public IEnumerable<Weapon> Weapons { get ; set; }
    }
    public class Example
    {
        public int status { get; set; }
        public Response response { get; set; }
        public int time { get; set; }
    }
