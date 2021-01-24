    public class Monster
    {
        public Monster(int hp, string name)
        {
            Hp = hp;
            Name = name;
        }
        public int Hp { get; protected set; }
        public string Name { get; protected set; }
    }
    public class Skeleton : Monster
    {
       public string Loot { get; set; } // <- Note added property.
       public Skeleton(int hp, string name) : base(hp, name)
       {
           Loot = "Sword";
       }
    }
    public class Vampire : Monster
    {
        //- some vampire specific properties
        public Vampire(int hp, string name) : base(hp, name)
        {
          // ...
        }
    }
