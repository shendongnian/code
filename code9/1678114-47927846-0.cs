    private const int maxHP = 3000;
    protected int hp;
    public int Hp {
        get
        {
            return hp;
        }
        protected set
        {
            // extra validation
            if(value < maxHP)
                hp = value;
            else
                hp = maxHP;
        }
    }
