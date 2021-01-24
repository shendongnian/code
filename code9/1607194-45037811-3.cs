    class Chicken
    {
        private int _hp;
        public int HP
        {
            get { return _hp; }
            set
            {
                if (_hp != value)
                {
                    _hp = value;
                    OnHPChanged();
                }
            }
        }
        public string Status { get; set; }
        private void OnHPChanged()
        {
            if (HP <= 0)
                Status = "Dead";
            else
                Status = "Alive";
        }
    }
