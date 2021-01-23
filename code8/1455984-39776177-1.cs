    public interface ICharacters
    {
        string sCharacterName { get; set; }
        List<IWeapon> Weapons { get; }
        void Equip(IWeapon toEquip);
    }
    public interface IWeapon
    {
        string sWeaponName { get; }
    }
    public class Character1Class : ICharacters
    {
        public string sCharacterName { get; set; }
        public List<IWeapon> Weapons { get; }
        public Character1Class(string v)
        {
            Weapons = new List<IWeapon>();
            sCharacterName = v;
        }
        public void Equip(IWeapon toEquip)
        {
            if (Weapons.Contains(toEquip))
                Console.WriteLine(sCharacterName + " equiped " + toEquip + ".");
            else Console.WriteLine(sCharacterName + " doesn't have " + toEquip + " to equip.");
        }
    }
    public class SwordClass : IWeapon
    {
        public string sWeaponName { get; }
        public SwordClass(string sName)
        {
            sWeaponName = sName;
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Character1Class character1 = new Character1Class("Frodo");
            SwordClass sword = new SwordClass("TestSword");
            character1.Weapons.Add(sword);
            character1.Equip(sword);
            Console.ReadKey();
        }
    }
