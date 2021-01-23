    public class MonsterFactory
    {
        private readonly Monster[] _monsters;
    
        public MonsterFactory(Monster[] monsters)
        {
            _monsters = monsters;
        }
    
        public Monster CreateMonster(MonsterType monsterType)
        {
            return _monsters.First(e => e.MonsterName == monsterType);
        }
    }
    
    public enum MonsterType
    {
        Dragon,
        Beast
    }
    
    public class Monster
    {
        public MonsterType MonsterName { get; set; }
        public int HitPoints { get; set; }
    }
