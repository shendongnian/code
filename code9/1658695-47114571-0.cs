    public interface IUnit
    {
        string Name   { get; }
        int    HP     { get; set; }
        int    Armor  { get; }
        int    Damage { get; }
    }
    public class Goblin : IUnit
    {
        public string Name { get; } = "Goblin";
        public int HP { get; set; } = 80;
        public int Armor  => 3;
        public int Damage => 8;
    }
    public class Knight : IUnit
    {
        public string Name { get; } = "Knight";
        public int HP { get; set; } = 120;
        public int Armor  => 5;
        public int Damage => 12;
    }
    public class BattleSystem
    {
        public void ProcessAttack (IUnit attacker, IUnit target)
        {
            Console.WriteLine (attacker.Name + " is attacking " + target.Name);
            int damage = Math.Max (0, attacker.Damage - target.Armor);
            target.HP -= damage;
            if (target.HP <= 0)
            {
                Console.WriteLine ("Enemy unit died...");
            }
        }
    }
