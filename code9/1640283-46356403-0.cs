    public enum State
    {
        None, // Idiomatically value 0 in .NET
        Idle,
        Patrol,
        Attack
    }
    public struct Monster
    {
        public string Name;
        public int Health;
        public int Damage;
        public State State;
        // Adjust this as required
        public override string ToString() =>
            $"Name: {Name}; Health: {Health}; Damage: {Damage}; State: {State}";
    }
    public List<Monster> monsters = new List<Monster>();
    
    void Start()
    {
        Debug.Log(string.Join(", ", monsters.Select(m => m.ToString().ToArray());
    }
