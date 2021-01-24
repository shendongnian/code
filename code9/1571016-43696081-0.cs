    class Fighter
    {
        public int Health = 100;
        public string Name;
        private Move _move;
        public string MoveName
        {
            get
            {
                return _move.Name;
            }
        }
        public int MoveDamage
        {
            get
            {
                return _move.Damage;
            }
        }
        public Fighter(string name, Move defaultMove)
        {
            Name = name;
            _move = defaultMove;
        }
        public void Attack(Fighter defendant)
        {
            if (_move != null)
                _move.Attack(defendant);
        }
        public void SetMove(Move move)
        {
            if (move != null)
                _move = move;
        }
    }
    abstract class Move
    {
        public int Damage { get; set; }
        public string Name { get; set; }
    
        protected Move(int damage,string name)
        {
            Damage = damage;
            Name = name;
        }
    
        public void Attack(Fighter defendant)
        {
            defendant.Health -= Damage;
        }
    }
    class PunchMove:Move
    {
        public PunchMove() : base(5, "Punch")
        {
        }
    }
    
    class KickMove:Move
    {
        public KickMove() : base(7, "Kick")
        {
        }
    }
