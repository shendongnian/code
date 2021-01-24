    class Dragon : Enemy 
    {
        public string DragonStuff { get; private set } 
        public Dragon(string _name, int _health, int _attack, int _level, string _dragonStuff) : base (_name, _health, _attack, _level)
        {
             DragonStuff = _dragonStuff;
        }
    }
