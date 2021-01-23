    public class WeaponUsed : HistoryEvent
    {
        public virtual Player Target { get; set; }
        public virtual GameCountry Country { get; set; }
        //Victims: Troops or Pops
        public IVictim Victims { get; set; }
        public bool HasMoreWeaponsLeft { get; set; }
    }
    public interface IVictim {
        // common methods and properties for PopVictim and TroopVictim
        int Number {get;}
    }
    public class TroopVictim : IVictim {
        // TroopVictim will be enforced to have IVictim methods and proprieties
        public int Number{ get {return 1; } }
    } 
    public class PopVictim : IVictim {
        // PopVictim will be enforced to have IVictim methods and proprieties
        public int Number{ get {return 100; } }
    } 
