    class Enemy
    {
        public string name;
        public int health;
        public int attack;
        public int level;
        public Enemy(string _name, int _health, int _attack, int _level)
        {
            name = _name;
            health = _health;
            attack = _attack;
            level = _level;
        }
        protected Enemy()
        {
            
        }
    }
